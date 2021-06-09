
namespace SISO_MFA_CONTROL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox_general = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_comport = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_close = new System.Windows.Forms.Button();
            this.comboBox_COM = new System.Windows.Forms.ComboBox();
            this.button_open = new System.Windows.Forms.Button();
            this.label_comport = new System.Windows.Forms.Label();
            this.groupBox_parameter = new System.Windows.Forms.GroupBox();
            this.textBox_N = new System.Windows.Forms.TextBox();
            this.button_set = new System.Windows.Forms.Button();
            this.textBox_Kc = new System.Windows.Forms.TextBox();
            this.label_N = new System.Windows.Forms.Label();
            this.label_Kc = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape4 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.textBox_output_tracking = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_setspeed = new System.Windows.Forms.Button();
            this.textBox_speed = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_stop = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox_general.SuspendLayout();
            this.groupBox_comport.SuspendLayout();
            this.groupBox_parameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_general
            // 
            this.groupBox_general.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_general.Controls.Add(this.label2);
            this.groupBox_general.Controls.Add(this.label1);
            this.groupBox_general.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox_general.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_general.ForeColor = System.Drawing.Color.Teal;
            this.groupBox_general.Location = new System.Drawing.Point(43, 40);
            this.groupBox_general.Name = "groupBox_general";
            this.groupBox_general.Size = new System.Drawing.Size(370, 103);
            this.groupBox_general.TabIndex = 0;
            this.groupBox_general.TabStop = false;
            this.groupBox_general.Text = "General ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "NHẬP MÔN ĐIỀU KHIỂN THÔNG MINH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "SISO MFA";
            // 
            // groupBox_comport
            // 
            this.groupBox_comport.Controls.Add(this.progressBar1);
            this.groupBox_comport.Controls.Add(this.button_close);
            this.groupBox_comport.Controls.Add(this.comboBox_COM);
            this.groupBox_comport.Controls.Add(this.button_open);
            this.groupBox_comport.Controls.Add(this.label_comport);
            this.groupBox_comport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_comport.ForeColor = System.Drawing.Color.Teal;
            this.groupBox_comport.Location = new System.Drawing.Point(43, 177);
            this.groupBox_comport.Name = "groupBox_comport";
            this.groupBox_comport.Size = new System.Drawing.Size(370, 163);
            this.groupBox_comport.TabIndex = 1;
            this.groupBox_comport.TabStop = false;
            this.groupBox_comport.Text = "Com Port Control ";
            this.groupBox_comport.Enter += new System.EventHandler(this.groupBox_comport_Enter);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(44, 126);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(276, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // button_close
            // 
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_close.Location = new System.Drawing.Point(187, 87);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(133, 33);
            this.button_close.TabIndex = 4;
            this.button_close.Text = "CLOSE";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // comboBox_COM
            // 
            this.comboBox_COM.FormattingEnabled = true;
            this.comboBox_COM.Location = new System.Drawing.Point(161, 42);
            this.comboBox_COM.Name = "comboBox_COM";
            this.comboBox_COM.Size = new System.Drawing.Size(159, 28);
            this.comboBox_COM.TabIndex = 3;
            this.comboBox_COM.Text = "COM4";
            // 
            // button_open
            // 
            this.button_open.BackColor = System.Drawing.Color.Transparent;
            this.button_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_open.Location = new System.Drawing.Point(44, 87);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(137, 33);
            this.button_open.TabIndex = 2;
            this.button_open.Text = "OPEN";
            this.button_open.UseVisualStyleBackColor = false;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // label_comport
            // 
            this.label_comport.AutoSize = true;
            this.label_comport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_comport.Location = new System.Drawing.Point(44, 48);
            this.label_comport.Name = "label_comport";
            this.label_comport.Size = new System.Drawing.Size(38, 15);
            this.label_comport.TabIndex = 0;
            this.label_comport.Text = "COM";
            // 
            // groupBox_parameter
            // 
            this.groupBox_parameter.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_parameter.Controls.Add(this.textBox_N);
            this.groupBox_parameter.Controls.Add(this.button_set);
            this.groupBox_parameter.Controls.Add(this.textBox_Kc);
            this.groupBox_parameter.Controls.Add(this.label_N);
            this.groupBox_parameter.Controls.Add(this.label_Kc);
            this.groupBox_parameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_parameter.ForeColor = System.Drawing.Color.Teal;
            this.groupBox_parameter.Location = new System.Drawing.Point(43, 362);
            this.groupBox_parameter.Name = "groupBox_parameter";
            this.groupBox_parameter.Size = new System.Drawing.Size(370, 173);
            this.groupBox_parameter.TabIndex = 2;
            this.groupBox_parameter.TabStop = false;
            this.groupBox_parameter.Text = "Parameter";
            this.groupBox_parameter.Enter += new System.EventHandler(this.groupBox_parameter_Enter);
            // 
            // textBox_N
            // 
            this.textBox_N.Location = new System.Drawing.Point(184, 79);
            this.textBox_N.Name = "textBox_N";
            this.textBox_N.Size = new System.Drawing.Size(136, 26);
            this.textBox_N.TabIndex = 8;
            this.textBox_N.Text = "0.2";
            // 
            // button_set
            // 
            this.button_set.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_set.Location = new System.Drawing.Point(44, 123);
            this.button_set.Name = "button_set";
            this.button_set.Size = new System.Drawing.Size(276, 33);
            this.button_set.TabIndex = 5;
            this.button_set.Text = "SET PARAMETERS";
            this.button_set.UseVisualStyleBackColor = true;
            this.button_set.Click += new System.EventHandler(this.button_set_Click);
            // 
            // textBox_Kc
            // 
            this.textBox_Kc.Location = new System.Drawing.Point(184, 43);
            this.textBox_Kc.Name = "textBox_Kc";
            this.textBox_Kc.Size = new System.Drawing.Size(136, 26);
            this.textBox_Kc.TabIndex = 7;
            this.textBox_Kc.Text = "0.042";
            // 
            // label_N
            // 
            this.label_N.AutoSize = true;
            this.label_N.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_N.Location = new System.Drawing.Point(44, 83);
            this.label_N.Name = "label_N";
            this.label_N.Size = new System.Drawing.Size(28, 15);
            this.label_N.TabIndex = 2;
            this.label_N.Text = "Eta";
            // 
            // label_Kc
            // 
            this.label_Kc.AutoSize = true;
            this.label_Kc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Kc.Location = new System.Drawing.Point(44, 47);
            this.label_Kc.Name = "label_Kc";
            this.label_Kc.Size = new System.Drawing.Size(23, 15);
            this.label_Kc.TabIndex = 1;
            this.label_Kc.Text = "Kc";
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.Location = new System.Drawing.Point(44, 37);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(137, 56);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "START";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.Teal;
            this.rectangleShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.rectangleShape1.BorderWidth = 2;
            this.rectangleShape1.Location = new System.Drawing.Point(18, 24);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(422, 684);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape4,
            this.rectangleShape3,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1340, 721);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape4
            // 
            this.rectangleShape4.BorderColor = System.Drawing.Color.Teal;
            this.rectangleShape4.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.rectangleShape4.BorderWidth = 2;
            this.rectangleShape4.Location = new System.Drawing.Point(846, 486);
            this.rectangleShape4.Name = "rectangleShape4";
            this.rectangleShape4.Size = new System.Drawing.Size(478, 139);
            // 
            // rectangleShape3
            // 
            this.rectangleShape3.BorderColor = System.Drawing.Color.Teal;
            this.rectangleShape3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.rectangleShape3.BorderWidth = 2;
            this.rectangleShape3.Location = new System.Drawing.Point(451, 485);
            this.rectangleShape3.Name = "rectangleShape3";
            this.rectangleShape3.Size = new System.Drawing.Size(387, 139);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BorderColor = System.Drawing.Color.Teal;
            this.rectangleShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.rectangleShape2.BorderWidth = 2;
            this.rectangleShape2.Location = new System.Drawing.Point(451, 23);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(874, 453);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(465, 40);
            this.chart1.MaximumSize = new System.Drawing.Size(838, 420);
            this.chart1.Name = "chart1";
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Setpoint";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Speed";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(838, 420);
            this.chart1.TabIndex = 5;
            this.chart1.TabStop = false;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button_clear);
            this.groupBox1.Controls.Add(this.button_exit);
            this.groupBox1.Controls.Add(this.textBox_output_tracking);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(861, 492);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 122);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphic";
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.Transparent;
            this.button_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear.Location = new System.Drawing.Point(42, 76);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(291, 33);
            this.button_clear.TabIndex = 6;
            this.button_clear.Text = "CLEAR GRAPHIC";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exit.Location = new System.Drawing.Point(339, 21);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(83, 88);
            this.button_exit.TabIndex = 7;
            this.button_exit.Text = "EXIT";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // textBox_output_tracking
            // 
            this.textBox_output_tracking.Location = new System.Drawing.Point(214, 39);
            this.textBox_output_tracking.Name = "textBox_output_tracking";
            this.textBox_output_tracking.Size = new System.Drawing.Size(119, 26);
            this.textBox_output_tracking.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "OUTPUT TRACKING";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button_setspeed);
            this.groupBox2.Controls.Add(this.textBox_speed);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(465, 492);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 122);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // button_setspeed
            // 
            this.button_setspeed.BackColor = System.Drawing.Color.Transparent;
            this.button_setspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_setspeed.Location = new System.Drawing.Point(44, 76);
            this.button_setspeed.Name = "button_setspeed";
            this.button_setspeed.Size = new System.Drawing.Size(291, 33);
            this.button_setspeed.TabIndex = 11;
            this.button_setspeed.Text = "SET SPEEED";
            this.button_setspeed.UseVisualStyleBackColor = false;
            this.button_setspeed.Click += new System.EventHandler(this.button_setspeed_Click);
            // 
            // textBox_speed
            // 
            this.textBox_speed.Location = new System.Drawing.Point(184, 39);
            this.textBox_speed.Name = "textBox_speed";
            this.textBox_speed.Size = new System.Drawing.Size(151, 26);
            this.textBox_speed.TabIndex = 4;
            this.textBox_speed.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "SPEED";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.button_stop);
            this.groupBox3.Controls.Add(this.progressBar2);
            this.groupBox3.Controls.Add(this.button_start);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Teal;
            this.groupBox3.Location = new System.Drawing.Point(43, 554);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 140);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // button_stop
            // 
            this.button_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_stop.Location = new System.Drawing.Point(183, 37);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(137, 56);
            this.button_stop.TabIndex = 7;
            this.button_stop.Text = "STOP";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(44, 99);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(276, 23);
            this.progressBar2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1340, 721);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_comport);
            this.Controls.Add(this.groupBox_general);
            this.Controls.Add(this.groupBox_parameter);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.shapeContainer1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_general.ResumeLayout(false);
            this.groupBox_general.PerformLayout();
            this.groupBox_comport.ResumeLayout(false);
            this.groupBox_comport.PerformLayout();
            this.groupBox_parameter.ResumeLayout(false);
            this.groupBox_parameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_general;
        private System.Windows.Forms.GroupBox groupBox_comport;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.ComboBox comboBox_COM;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Label label_comport;
        private System.Windows.Forms.GroupBox groupBox_parameter;
        private System.Windows.Forms.Label label_N;
        private System.Windows.Forms.Label label_Kc;
        private System.Windows.Forms.TextBox textBox_N;
        private System.Windows.Forms.TextBox textBox_Kc;
        private System.Windows.Forms.Button button_start;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.TextBox textBox_output_tracking;
        private System.Windows.Forms.Label label4;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_setspeed;
        private System.Windows.Forms.TextBox textBox_speed;
        private System.Windows.Forms.Label label7;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape4;
        private System.Windows.Forms.Button button_set;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

