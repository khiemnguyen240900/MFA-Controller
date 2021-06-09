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
using System.Diagnostics;


namespace SISO_MFA_CONTROL
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch;
        public byte[] rxbuff = new byte[9];
        public byte[] txbuff = new byte[22];                                                
        public float setpoint;
        public double t = 0, speed = 0;
        public bool isChart = false;
        mydata txdata, rxdata;
        checksum cs;
       
        public Form1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
        }

        private void Form1_Load(object sender, EventArgs e)                                     // ComPort
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox_COM.Items.AddRange(ports);
        }

        private void button_open_Click(object sender, EventArgs e)                              // Button Open UART
        {
            try
            {
                serialPort1.PortName = comboBox_COM.Text;
                serialPort1.BaudRate = 115200;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                serialPort1.Open();
                progressBar1.Value = 100;
            }
            catch
            {
                MessageBox.Show("Invalid textBox!");
            }
        }

        private void button_set_Click(object sender, EventArgs e)                               // Button Set
        {
            try
            {
                // lấy giá trị nhập vào trước để kiểm tra lỗi "Invalid Setpoint"
                txdata.myfloat = float.Parse(textBox_N.Text);
                txdata.myfloat = float.Parse(textBox_Kc.Text);

                // chuyển Kc vào txbuff
                txdata.myfloat = float.Parse(textBox_Kc.Text);
                txdata.mybyte = BitConverter.GetBytes(txdata.myfloat);
                for (int i = 0; i < 4; i++)
                {
                    txbuff[3 + i] = txdata.mybyte[i];
                }

                // chuyển Eta vào txbuff
                txdata.myfloat = float.Parse(textBox_N.Text);
                txdata.mybyte = BitConverter.GetBytes(txdata.myfloat);
                for (int i = 0; i < 4; i++)
                {
                    txbuff[7 + i] = txdata.mybyte[i];
                }

                txbuff[0] = (byte)'M';
                txbuff[1] = (byte)'F';
                txbuff[2] = (byte)'A';

                // txbuff[8:11] = SETPOINT
                // txbuff[12:15] = Kc
                // txbuff[16:19] = Eta

                //checksum
                cs.Tx = 0;
                for (int i = 0; i < 11; i++)
                {
                    cs.Tx += txbuff[i];
                }
                txbuff[11] = (byte)cs.Tx;
                txbuff[12] = (byte)'$';

                //truyền txbuff
                serialPort1.Write(txbuff, 0, 13);
            }
            catch
            {
                MessageBox.Show("Invalid Parameters");
            }
        }

        private void button_close_Click(object sender, EventArgs e)                             // Button Close
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
            }
        }

        private void button_start_Click(object sender, EventArgs e)                             // Button Start
        {
            try
            {                                                                               
                {
                    // bật Timer
                    timer1.Start();
                    button_start.BackColor = Color.LightGreen;
                    button_stop.BackColor = Color.White;
                    progressBar2.Value = 100;

                    // frame truyền txbuff
                    txbuff[0] = (byte)'M';
                    txbuff[1] = (byte)'F';
                    txbuff[2] = (byte)'A';
                    txbuff[3] = (byte)'S';
                    txbuff[4] = (byte)'T';
                    txbuff[5] = (byte)'A';
                    txbuff[6] = (byte)'R';
                    txbuff[7] = (byte)'T';
                    txbuff[8] = (byte)'-';
                    txbuff[9] = (byte)'-';
                    txbuff[10] = (byte)'-';

                    //checksum
                    cs.Tx = 0;
                    for (int i = 0; i < 11; i++)
                    {
                        cs.Tx += txbuff[i];
                    }
                    txbuff[11] = (byte)cs.Tx;
                    txbuff[12] = (byte)'$';

                    //truyền txbuff
                    serialPort1.Write(txbuff, 0, 13);
                }
            }
            catch
            {
                MessageBox.Show("Invalid Parameters");
            }
        }

        private void button_stop_Click(object sender, EventArgs e)                              // Button Stop
        {
            if (serialPort1.IsOpen)
            {
                timer1.Stop();
                stopwatch.Reset();
                chart1.Series[0].Points.Clear();
                button_stop.BackColor = Color.LightYellow;
                button_start.BackColor = Color.White;
                progressBar2.Value = 0;

                // set frame txbuff
                txbuff[0] = (byte)'M';
                txbuff[1] = (byte)'F';
                txbuff[2] = (byte)'A';
                txbuff[3] = (byte)'S';
                txbuff[4] = (byte)'T';
                txbuff[5] = (byte)'O';
                txbuff[6] = (byte)'P';
                txbuff[7] = (byte)'-';
                txbuff[8] = (byte)'-';
                txbuff[9] = (byte)'-';
                txbuff[10] = (byte)'-';

                // checksum
                cs.Tx = 0;
                for (int i = 0; i < 11; i++)
                {
                    cs.Tx += txbuff[i];
                }
                txbuff[11] = (byte)cs.Tx;
                txbuff[12] = (byte)'$';

                // truyền txbuff
                serialPort1.Write(txbuff, 0, 13);
            }
        }

        private void button_setspeed_Click(object sender, EventArgs e)                          // Button Setspeed
        {
            try
            {
                // txbuff = {'M','F','A','S','S','P','D','SPEED','SPEED','SPEED','SPEED','Cx_tx','$'} = 13byte
                //
                txdata.myfloat = float.Parse(textBox_speed.Text);
                txdata.mybyte = BitConverter.GetBytes(txdata.myfloat);


                // lấy dữ liệu Setpoint = Speed để vẽ Chart
                setpoint = float.Parse(textBox_speed.Text);

                // chuyển Speed vào frame txbuff
                for (int i = 0; i < 4; i++)
                {
                    txbuff[7 + i] = txdata.mybyte[i];
                }
                txbuff[0] = (byte)'M';
                txbuff[1] = (byte)'F';
                txbuff[2] = (byte)'A';
                txbuff[3] = (byte)'S';
                txbuff[4] = (byte)'S';
                txbuff[5] = (byte)'P';
                txbuff[6] = (byte)'D';
                //txbuff[7:10] = SPEED

                // checksum
                cs.Tx = 0;
                for (int i = 0; i < 11; i++)
                {
                    cs.Tx += txbuff[i];
                }
                txbuff[11] = (byte)cs.Tx;
                txbuff[12] = (byte)'$';

                // truyền txbuff
                serialPort1.Write(txbuff, 0, 13);
            }
            catch
            {
                MessageBox.Show("Invalid Set Speed");
            }
        }

        private void button_clear_Click(object sender, EventArgs e)                             // Button Clear
        {
            stopwatch.Reset();
            chart1.Series[0].Points.Clear();
        }

        private void button_exit_Click(object sender, EventArgs e)                              // Button Exit
        {
            this.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)     // Recieve
        {
            // nhận frame theo thứ tự từ rxbuff[0:8] = rxbuff = {'M','F','A','S0','S1','S2','S3','c','$'} = 9 byte
            serialPort1.Read(rxbuff, 0, 9);
            stopwatch.Start();
            isChart = true;
            cs.Rx = 0;
            for (int i = 0; i < 7; i++)
            {
                cs.Rx += rxbuff[i];
            }
            // kiểm tra frame nhận rxbuff
            // tính giá trị Speed nhận được từ STM
            // if (rxbuff[0] == 'M' && rxbuff[1] == 'F' && rxbuff[2] == 'A' && rxbuff[8] == '$')
            if (rxbuff[0] == 'M' && rxbuff[1] == 'F' && rxbuff[2] == 'A' && rxbuff[8] == '$')
            {
                rxdata.myfloat = BitConverter.ToSingle(rxbuff, 3);
                speed = Convert.ToDouble(rxdata.myfloat)*1.012;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)                                    // Chart1
        {
            
            // vẽ chart
            if (isChart)
            {
                t = stopwatch.Elapsed.TotalSeconds;
                chart1.ChartAreas[0].AxisX.Interval = 0.50;
                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("", 6);
                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart1.Series[0].Points.AddXY(t, setpoint);
                chart1.Series[1].Points.AddXY(t, speed);
                if (chart1.Series[0].Points.Count > 500)
                    chart1.Series[0].Points.RemoveAt(0);
                chart1.ChartAreas[0].AxisX.Maximum = stopwatch.Elapsed.TotalSeconds;
                chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;

                textBox_output_tracking.Text = Math.Round(speed,2).ToString();
                isChart = false;
            }
        }







        private void label_setpoint_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_parameter_Enter(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_comport_Enter(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_setpoint_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


