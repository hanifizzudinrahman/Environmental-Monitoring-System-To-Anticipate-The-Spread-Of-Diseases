import RPi.GPIO as gp
from datetime import datetime as dtm
from picamera import PiCamera
import time
import os

gp.setwarnings(False)
gp.setmode(gp.BOARD)

gp.setup(7, gp.OUT)
gp.setup(11, gp.OUT)
gp.setup(12, gp.OUT)

control_pins = [13,15,16,22]
for pin in control_pins:
  gp.setup(pin, gp.OUT)
  gp.output(pin, 0)
halfstep_seq = [
  [1,0,0,0],
  [1,1,0,0],
  [0,1,0,0],
  [0,1,1,0],
  [0,0,1,0],
  [0,0,1,1],
  [0,0,0,1],
  [1,0,0,1]
]
halfstep_seq_REVERSE = [
  [0,0,0,1],
  [0,0,1,1],
  [0,0,1,0],
  [0,1,1,0],
  [0,1,0,0],
  [1,1,0,0],
  [1,0,0,0],
  [1,0,0,1]
]

gp.output(11, True)
gp.output(12, True)

saat_ini = dtm.now() #tgl dan jam saat ini
now = dtm.strftime(saat_ini, '%d-%b-%Y_%H:%M:%S') # tpye = string

camera = PiCamera(resolution = (3280, 2464))

#camera = PiCamera(resolution = (3280, 2464))
#camera.rotation = 180

def main():
    
    print("Start testing the camera A RGB ", now)
    i2c = "i2cset -y 1 0x70 0x00 0x04"
    os.system(i2c)
    gp.output(7, False)
    gp.output(11, False)
    gp.output(12, True)
    captureRGB(1)     # RGB
    
    print("Start testing the camera C NoIR Band2")
    i2c = "i2cset -y 1 0x70 0x00 0x06"
    os.system(i2c)
    gp.output(7, False)
    gp.output(11, True)
    gp.output(12, False)
    captureNoIR(2)
    for i in range(128):           # 90 Derajat Kanan
      for halfstep in range(8):
        for pin in range(4):
          gp.output(control_pins[pin], halfstep_seq_REVERSE[halfstep][pin])
        time.sleep(0.001)
    print('Putaran 1')
    
    print("Start testing the camera C NoIR Band3", now)
    captureNoIR(3)     # BAND 3
    for i in range(256):           # 180 Derajat Kiri
      for halfstep in range(8):
        for pin in range(4):
          gp.output(control_pins[pin], halfstep_seq[halfstep][pin])
        time.sleep(0.001)
    print('Putaran 2')
    
    print("Start testing the camera C NoIR Band1", now)
    captureNoIR(1)     # BAND 1
    for i in range(128):           # 90 Derajat Kanan
      for halfstep in range(8):
        for pin in range(4):
          gp.output(control_pins[pin], halfstep_seq_REVERSE[halfstep][pin])
        time.sleep(0.001)
    print('Putaran 3')

def captureNoIR(cam):
    camera.rotation = 180
    camera.start_preview(resolution=(1920,1080))
    time.sleep(3.5)             # Waktu Pengambilan Gambar
    if cam == 1:
        camera.capture("/home/pi/TA/[PA_2]/[Hasil_Gambar]/NoIR_Band1_%s.jpg" % now)
    elif cam == 2:
        camera.capture("/home/pi/TA/[PA_2]/[Hasil_Gambar]/NoIR_Band2_%s.jpg" % now)
    else:
        camera.capture("/home/pi/TA/[PA_2]/[Hasil_Gambar]/NoIR_Band3_%s.jpg" % now)
    camera.stop_preview()

def captureRGB(cam):
    camera.rotation = 180
    camera.start_preview(resolution=(1920,1080))
    time.sleep(3.5)             # Waktu Pengambilan Gambar
    camera.capture("/home/pi/TA/[PA_2]/[Hasil_Gambar]/RGB_%s.jpg" % now)
    camera.stop_preview()

if __name__ == "__main__":
    main()

    gp.output(7, False)
    gp.output(11, False)
    gp.output(12, True)
    gp.cleanup()
    os._exit(0)





