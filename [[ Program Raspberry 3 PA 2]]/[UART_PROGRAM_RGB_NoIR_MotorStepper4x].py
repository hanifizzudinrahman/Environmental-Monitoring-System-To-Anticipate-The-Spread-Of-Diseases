#!/usr/bin/env python
import time
import serial
import os

ser = serial.Serial(
 port='/dev/ttyUSB0',     # Di Atas Kanan
 #port='/dev/ttyUSB1',      #Di Bawah Kanan
 baudrate = 57600,
 parity=serial.PARITY_NONE,
 stopbits=serial.STOPBITS_ONE,
 bytesize=serial.EIGHTBITS,
 timeout=1
)

def main():
    cd = "/home/pi/TA/[PA_2]"
    os.chdir(cd)
    sudocamera = "python3 [PROGRAM_RGB-NoIR_MotorStepper4x].py"
    os.system(sudocamera)
def mainKanan():
    cd = "/home/pi/TA/UART Comunication"
    os.chdir(cd)
    sudocameraKanan = "python3 [IF-FULL_MotorKanan].py"
    os.system(sudocameraKanan)
def mainKiri():
    cd = "/home/pi/TA/UART Comunication"
    os.chdir(cd)
    sudocameraKiri = "python3 [IF-FULL_MotorKiri].py"
    os.system(sudocameraKiri)
def motorFinal():
    cd = "/home/pi/TA/[PA_2]"
    os.chdir(cd)
    sudomotorFinal = "python3 Motor_Stepper_Final.py"
    os.system(sudomotorFinal)
def camera2():
    cd = "/home/pi/TA/[PA_2]"
    os.chdir(cd)
    sudocamera2 = "python3 Camera_RGB-NoIR.py"
    os.system(sudocamera2)

counter = 1
test = 1
camera = 1

ser.write(b'Camera Ready! ')
while 1:
 x=ser.readline().decode('ascii')
 if x == 'go':
     ser.write(b'-Received %d-'%(counter))
     main()
     ser.write(b'-FINISH %d- '%(counter))
     counter += 1
 elif x == 'cam':
     ser.write(b'-dapat cam %d-'%(camera))
     camera2()
     ser.write(b'-selesai cam %d- '%(camera))
     camera += 1
 elif x == 'test':
     ser.write(b'-test diterima %d-' %(test))
     test += 1
 elif x == 'motor':
     motorFinal()
     ser.write(b'-motor ok %d-' %(test))
     test += 1
 elif x == 'kanan':
     ser.write(b'-Kanan Received%d-'%(counter))
     mainKanan()
     ser.write(b'-Kanan FINISH%d- '%(counter))
     counter += 1
 elif x == 'kiri':
     ser.write(b'-Kiri Received%d-'%(counter))
     mainKiri()
     ser.write(b'-Kiri FINISH%d- '%(counter))
     counter += 1
 elif x == 'exit':
     ser.write(b' -EXIT- ')
     os.system("sudo shutdown -h now")

 print (x)