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

gp.output(11, True)
gp.output(12, True)

saat_ini = dtm.now() #tgl dan jam saat ini
now = dtm.strftime(saat_ini, '%d-%b-%Y_%H:%M:%S') # tpye = string

camera = PiCamera(resolution = (3280, 2464))

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
