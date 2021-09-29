# Environmental-Monitoring-System-To-Anticipate-The-Spread-Of-Diseases
![image](https://user-images.githubusercontent.com/47806867/135240053-676cfa2c-835c-4b8b-9a5e-d20d78f858d7.png)

In this project, we use a Spectral Camera to observe a crowd using a drone. The spectral camera that we make has several filters for the wavelength of light, namely
- RGB camera (400 – 700)nm

![image](https://user-images.githubusercontent.com/47806867/135239359-d313d065-bbdb-49e0-b635-097b6c3d4d17.png)
- Camera NoIR A + MidOpt Filter (770-790)nm

![image](https://user-images.githubusercontent.com/47806867/135239381-4e870816-3077-4a3c-ba87-4ad3193140d9.png)
- NoIR B Camera + MidOpt Filter (855-890)nm

![image](https://user-images.githubusercontent.com/47806867/135239402-a10bb1be-a863-4990-9347-38bb9c711c43.png)
- Camera NoIR C + MidOpt Filter (929-955)nm

![image](https://user-images.githubusercontent.com/47806867/135239423-82cc71a9-a9f7-425c-a0d0-bc66ace14c48.png)

The multispectral camera will take several pictures of the crowd and use it as a dataset to find out how many people are in the crowd. The deep learning process is carried out using the CSRNet architecture and the learning process is also integrated with the ShanghaiTech Dataset crowd dataset. To take an images is managed with a GUI that has been created on the laptop, and is connected serially via the Telemtry module

- Hardware: Raspberry Pi 3, Multi Camera Adapter V2.2, 1 Camera RGB and 3 NoIR, Telemtry Module, DJI Drone, Casing 3D Design, Cutting Acrylic
- Tools: Python (OpenCV), C# (GUI Desktop), I2C Protocol (SDA/SCL), SPI (MISO/MOSI/CLK), UART, Fusion360, Corel Draw 2020
- Deep Learning: Python (TensorFlow), CSRNet architecture
- Step:
1. Get a Dataset
2. Deep Learning
3. Inference

*Result: Its accuracy is only 18% and it is poor. This is because the dataset was taken using an inappropriate multispectral camera

GUI Camera Multispectral V4.1

![image](https://user-images.githubusercontent.com/47806867/135239554-dfde3e74-a77b-459e-93ea-1f540df6d0ff.png)

Camera Multispectral

![IMG_20210630_211655](https://user-images.githubusercontent.com/47806867/135239104-29abcfbd-39f2-4e15-9216-e62f4b9dbbab.jpg)
![IMG_20210630_211835](https://user-images.githubusercontent.com/47806867/135239137-b5ba562d-b8ad-4192-aaec-e33ef267ea52.jpg)

Design 3D

![image](https://user-images.githubusercontent.com/47806867/135239260-39073135-3f72-4793-90b9-cce2464a326a.png)

Range Spectral

![image](https://user-images.githubusercontent.com/47806867/135239288-c86020ef-2336-4407-acdf-5b8a4a4f060e.png)

Result Density

![image](https://user-images.githubusercontent.com/47806867/135239474-240ab6f0-13ef-4e70-8ec4-d301c7c3a183.png)
