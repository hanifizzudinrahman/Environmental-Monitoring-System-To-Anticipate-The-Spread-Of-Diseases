# Environmental-Monitoring-System-To-Anticipate-The-Spread-Of-Diseases

In this project, we use a Spectral Camera to observe a crowd using a drone. The spectral camera that we make has several filters for the wavelength of light, namely
a. RGB camera (400 – 700)nm
b. Camera NoIR A + MidOpt Filter (770-790)nm
c. NoIR B Camera + MidOpt Filter (855-890)nm
d. Camera NoIR C + MidOpt Filter (929-955)nm
The multispectral camera will take several pictures of the crowd and use it as a dataset to find out how many people are in the crowd. The deep learning process is carried out using the CSRNet architecture and the learning process is also integrated with the ShanghaiTech Dataset crowd dataset. To take an images is managed with a GUI that has been created on the laptop, and is connected serially via the Telemtry module

- Hardware: Raspberry Pi 3, Multi Camera Adapter V2.2, 1 Camera RGB and 3 NoIR, Telemtry Module, DJI Drone, Casing 3D Design, Cutting Acrylic
- Tools: Python (OpenCV), C# (GUI Desktop), I2C Protocol (SDA/SCL), SPI (MISO/MOSI/CLK), UART, Fusion360, Corel Draw 2020
- Deep Learning: Python (TensorFlow), CSRNet architecture
- Step:
1. Get a Dataset
2. Deep Learning
3. Inference

*Result: Its accuracy is only 18% and it is poor. This is because the dataset was taken using an inappropriate multispectral camera
