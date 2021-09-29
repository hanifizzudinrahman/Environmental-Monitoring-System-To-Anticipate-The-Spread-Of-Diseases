using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Camera_Spectral_Video_V4
{
    public partial class Form_V3 : Form
    {
        string dataOUT;
        string dataIN;

        string singleCam, cam, camFinal, optional;

        bool Timer, labelRed;
        // Duration
        int Hours, Minutes, Seconds;
        int Time;

        public Form_V3()
        {
            InitializeComponent();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox_ComPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox_BaudRate.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), comboBox_ParityBits.Text);
                serialPort1.DataBits = Convert.ToInt32(comboBox_DataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBox_StopBits.Text);

                serialPort1.Open();
                progressBar_Connect.Value = 100;
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_V3_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox_ComPort.Items.AddRange(ports);

            //

            checkBox_AlwaysUpdate.Checked = false;
            checkBox_AddOldData.Checked = true;
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                dataOUT = textBox_Transmitter.Text;
                //serialPort1.WriteLine(dataOUT);       // Ada Enternya
                serialPort1.Write(dataOUT);             // Gk Ada Enternya
            }
        }

        private void button_CamA_Click(object sender, EventArgs e)
        {
            if (radioButton_Horizontal.Checked)
            {
                if (radioButton_Original.Checked)
                    cam = "H_CamA";
                else if (radioButton_Callibrated.Checked)
                    cam = "H_Callibrated_CamA";
            }
            else if (radioButton_Vertical.Checked)
            {
                if (radioButton_Original.Checked)
                    cam = "V_CamA";
                else if (radioButton_Callibrated.Checked)
                    cam = "V_Callibrated_CamA";
            }
            serialPort1.Write(cam);
        }

        private void button_CamB_Click(object sender, EventArgs e)
        {
            if (radioButton_Horizontal.Checked)
            {
                if (radioButton_Original.Checked)
                    cam = "H_CamB";
                else if (radioButton_Callibrated.Checked)
                    cam = "H_Callibrated_CamB";
            }
            else if (radioButton_Vertical.Checked)
            {
                if (radioButton_Original.Checked)
                    cam = "V_CamB";
                else if (radioButton_Callibrated.Checked)
                    cam = "V_Callibrated_CamB";
            }
            serialPort1.Write(cam);
        }

        private void button_CamC_Click(object sender, EventArgs e)
        {
            if (radioButton_Horizontal.Checked)
            {
                if (radioButton_Original.Checked)
                    cam = "H_CamC";
                else if (radioButton_Callibrated.Checked)
                    cam = "H_Callibrated_CamC";
            }
            else if (radioButton_Vertical.Checked)
            {
                if (radioButton_Original.Checked)
                    cam = "V_CamC";
                else if (radioButton_Callibrated.Checked)
                    cam = "V_Callibrated_CamC";
            }
            serialPort1.Write(cam);
        }

        private void button_CamD_Click(object sender, EventArgs e)
        {
            if (radioButton_Horizontal.Checked)
            {
                if (radioButton_Original.Checked)
                    cam = "H_CamD";
                else if (radioButton_Callibrated.Checked)
                    cam = "H_Callibrated_CamD";
            }
            else if (radioButton_Vertical.Checked)
            {
                if (radioButton_Original.Checked)
                    cam = "V_CamD";
                else if (radioButton_Callibrated.Checked)
                    cam = "V_Callibrated_CamD";
            }
            serialPort1.Write(cam);
        }

        private void button_CamABCD_Click(object sender, EventArgs e)
        {
            if (radioButton_Horizontal.Checked)
            {
                if (radioButton_Original.Checked)
                {
                    if (radioButton_Normal.Checked)
                        camFinal = "H_Cam_ABCD";
                    else if (radioButton_Fast.Checked)
                        camFinal = "H_Cam_FAST_ABCD";
                }
                else if (radioButton_Callibrated.Checked)
                {
                    if (radioButton_Normal.Checked)
                        camFinal = "H_Callibrated_Cam_ABCD";
                    else if (radioButton_Fast.Checked)
                        camFinal = "H_Callibrated_Cam_FAST_ABCD";
                }
            }
            else if (radioButton_Vertical.Checked)
            {
                if (radioButton_Original.Checked)
                {
                    if (radioButton_Normal.Checked)
                        camFinal = "V_Cam_ABCD";
                    else if (radioButton_Fast.Checked)
                        camFinal = "V_Cam_FAST_ABCD";
                }
                else if (radioButton_Callibrated.Checked)
                {
                    if (radioButton_Normal.Checked)
                        camFinal = "V_Callibrated_Cam_ABCD";
                    else if (radioButton_Fast.Checked)
                        camFinal = "V_Callibrated_Cam_FAST_ABCD";
                }
            }
            serialPort1.Write(camFinal);
        }

        private void button_CamRealTimeABCD_Click(object sender, EventArgs e)
        {
            if (radioButton_Horizontal.Checked)
            {
                if (radioButton_Original.Checked)
                    camFinal = "H_RealTime_4Cam_ABCD";
                else if (radioButton_Callibrated.Checked)
                    camFinal = "H_Callibrated_RealTime_4Cam_ABCD";
            }
            else if (radioButton_Vertical.Checked)
            {
                if (radioButton_Original.Checked)
                    camFinal = "V_RealTime_4Cam_ABCD";
                else if (radioButton_Callibrated.Checked)
                    camFinal = "V_Callibrated_RealTime_4Cam_ABCD";
            }
            serialPort1.Write(camFinal);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            optional = "test";
            serialPort1.Write(optional);
        }

        private void button_ClearTransmitter_Click(object sender, EventArgs e)
        {
            if (textBox_Transmitter.Text != "")
            {
                textBox_Transmitter.Text = "";
            }
        }

        private void checkBox_AlwaysUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AlwaysUpdate.Checked)
            {
                checkBox_AlwaysUpdate.Checked = true;
                checkBox_AddOldData.Checked = false;
            }
            else { checkBox_AddOldData.Checked = true; }
        }

        private void checkBox_AddOldData_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AddOldData.Checked)
            {
                checkBox_AlwaysUpdate.Checked = false;
                checkBox_AddOldData.Checked = true;
            }
            else { checkBox_AlwaysUpdate.Checked = true; }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }

        private void ShowData(object sender, EventArgs e)
        {
            if (checkBox_AlwaysUpdate.Checked)
            {
                textBox_Receiver.Text = dataIN;
            }
            else if (checkBox_AddOldData.Checked)
            {
                textBox_Receiver.Text += dataIN;
            }
        }

        private void button_Restart_Click(object sender, EventArgs e)
        {
            optional = "restart";
            serialPort1.Write(optional);
        }

        private void button_ShutDown_Click(object sender, EventArgs e)
        {
            optional = "shutdown";
            serialPort1.Write(optional);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button_Record_Click(object sender, EventArgs e)
        {
            string StringTime, rec;
            rec = "";
            Timer = true;
            labelRed = false;

            Hours = Convert.ToInt32(numericUpDown_Hours.Text);
            Minutes = Convert.ToInt32(numericUpDown_Minutes.Text);
            Seconds = Convert.ToInt32(numericUpDown_Seconds.Text);
            Time = convert2Seconds(Hours, Minutes, Seconds);
            StringTime = Convert.ToString(Time);

            // Code
            if (radioButton_RecHorizontal.Checked)
            {
                if (radioButton_SingleCamera.Checked)
                    rec = "H_RecSingle_Cam";
                else if (radioButton_MultiCamera.Checked)
                {
                    if (radioButton_RecOriginal.Checked)
                    {
                        if (radioButton_A.Checked)
                            rec = "H_RecCamA";
                        else if (radioButton_B.Checked)
                            rec = "H_RecCamB";
                        else if (radioButton_C.Checked)
                            rec = "H_RecCamC";
                        else if (radioButton_D.Checked)
                            rec = "H_RecCamD";
                        else if (radioButton_ABCD.Checked)
                        {
                            if (radioButton_NotSeparated.Checked)
                                rec = "H_Rec_RealTime_ABCD";
                            else if (radioButton_Separated.Checked)
                                rec = "H_RecSeparated_RealTime_ABCD";
                        }
                    }
                    else if (radioButton_RecCallibrated.Checked)
                    {
                        if (radioButton_A.Checked)
                            rec = "H_Rec_CallibratedCamA";
                        else if (radioButton_B.Checked)
                            rec = "H_Rec_CallibratedCamB";
                        else if (radioButton_C.Checked)
                            rec = "H_Rec_CallibratedCamC";
                        else if (radioButton_D.Checked)
                            rec = "H_Rec_CallibratedCamD";
                        else if (radioButton_ABCD.Checked)
                        {
                            if (radioButton_NotSeparated.Checked)
                                rec = "H_Rec_CallibratedRealTime_ABCD";
                            else if (radioButton_Separated.Checked)
                                rec = "H_RecSeparated_CallibratedRealTime_ABCD";
                        }
                    }
                }
            }
            else if (radioButton_RecVertical.Checked)
            {
                if (radioButton_SingleCamera.Checked)
                    rec = "V_RecSingle_Cam";
                else if (radioButton_MultiCamera.Checked)
                {
                    if (radioButton_RecOriginal.Checked)
                    {
                        if (radioButton_A.Checked)
                            rec = "V_RecCamA";
                        else if (radioButton_B.Checked)
                            rec = "V_RecCamB";
                        else if (radioButton_C.Checked)
                            rec = "V_RecCamC";
                        else if (radioButton_D.Checked)
                            rec = "V_RecCamD";
                        else if (radioButton_ABCD.Checked)
                        {
                            if (radioButton_NotSeparated.Checked)
                                rec = "V_Rec_RealTime_ABCD";
                            else if (radioButton_Separated.Checked)
                                rec = "V_RecSeparated_RealTime_ABCD";
                        }
                    }
                    else if (radioButton_RecCallibrated.Checked)
                    {
                        if (radioButton_A.Checked)
                            rec = "V_Rec_CallibratedCamA";
                        else if (radioButton_B.Checked)
                            rec = "V_Rec_CallibratedCamB";
                        else if (radioButton_C.Checked)
                            rec = "V_Rec_CallibratedCamC";
                        else if (radioButton_D.Checked)
                            rec = "V_Rec_CallibratedCamD";
                        else if (radioButton_ABCD.Checked)
                        {
                            if (radioButton_NotSeparated.Checked)
                                rec = "V_Rec_CallibratedRealTime_ABCD";
                            else if (radioButton_Separated.Checked)
                                rec = "V_RecSeparated_CallibratedRealTime_ABCD";
                        }
                    }
                }
            }
            string syntax = "#";
            rec = StringTime + syntax + rec;
            Console.WriteLine(rec);
            serialPort1.Write(rec);
        }

        private int convert2Seconds(int hours, int minutes, int seconds)
        {
            int time;

            time = hours * 60 * 60 + minutes * 60 + seconds;

            return time;                
        }

        private void button_RecClear_Click(object sender, EventArgs e)
        {
            Timer = false;

            label_Hours.ForeColor = Color.Black;
            label_Minutes.ForeColor = Color.Black;
            label_Seconds.ForeColor = Color.Black;
            label_Hours.Text = "00";
            label_Minutes.Text = "00";
            label_Seconds.Text = "00";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Timer == true)
            {

                if (Seconds != 0)
                {
                    Seconds--;
                }
                else
                {
                    if (Minutes != 0)
                    {
                        Minutes--;
                        Seconds = 60;
                    }
                    else
                    {
                        if (Hours != 0)
                        {
                            Hours--;
                            Minutes = 60;
                        }
                        else
                        {
                            if (labelRed)
                            {
                                // Black Label
                                label_Hours.ForeColor = Color.Black;
                                label_Minutes.ForeColor = Color.Black;
                                label_Seconds.ForeColor = Color.Black;
                                labelRed = false;
                            }
                            else
                            {
                                // Red Label
                                label_Hours.ForeColor = Color.Red;
                                label_Minutes.ForeColor = Color.Red;
                                label_Seconds.ForeColor = Color.Red;
                                labelRed = true;
                            }
                        }
                    }

                }
                // Print Time
                label_Hours.Text = Convert.ToString(Hours);
                label_Minutes.Text = Convert.ToString(Minutes);
                label_Seconds.Text = Convert.ToString(Seconds);


            }
        }

        private void button_ClearReceiver_Click(object sender, EventArgs e)
        {
            if (textBox_Receiver.Text != "")
            {
                textBox_Receiver.Text = "";
            }
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar_Connect.Value = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton_Horizontal.Checked)
                singleCam = "H_Single_Cam";
            else if (radioButton_Vertical.Checked)
                singleCam = "V_Single_Cam";
            serialPort1.Write(singleCam);
        }
    }
}
