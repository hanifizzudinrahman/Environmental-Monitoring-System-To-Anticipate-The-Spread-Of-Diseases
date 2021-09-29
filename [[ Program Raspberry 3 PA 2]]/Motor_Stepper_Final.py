import RPi.GPIO as gp
import time
import os

gp.setwarnings(False)
gp.setmode(gp.BOARD)

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
    
for i in range(128):           # 90 Derajat Kanan
  for halfstep in range(8):
    for pin in range(4):
       gp.output(control_pins[pin], halfstep_seq_REVERSE[halfstep][pin])
    time.sleep(0.001)
print('Putaran 1')
time.sleep(0.5)
    
for i in range(256):           # 180 Derajat Kiri
  for halfstep in range(8):
    for pin in range(4):
       gp.output(control_pins[pin], halfstep_seq[halfstep][pin])
    time.sleep(0.001)
print('Putaran 2')
time.sleep(0.5)
    
for i in range(128):           # 90 Derajat Kanan
  for halfstep in range(8):
    for pin in range(4):
       gp.output(control_pins[pin], halfstep_seq_REVERSE[halfstep][pin])
    time.sleep(0.001)
print('Putaran 3')
time.sleep(0.5)
    
gp.cleanup()
os._exit(0)

