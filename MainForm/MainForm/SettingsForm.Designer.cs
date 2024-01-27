namespace MainForm
{
    partial class SettingsForm
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
            labelVersionAccess = new Label();
            textBoxVersionAccess = new TextBox();
            labelMeasurementValues = new Label();
            textBoxMeasurementValues = new TextBox();
            groupBox1 = new GroupBox();
            textBoxTypeMeasure = new TextBox();
            label_TypeMeasure = new Label();
            textBoxUIDPowerConsump = new TextBox();
            labelUIDPowerConsump = new Label();
            textBoxNameServer = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            comboBox1 = new ComboBox();
            labelPowerSystem = new Label();
            label_InitPower = new Label();
            textBoxInitPower = new TextBox();
            buttonOK = new Button();
            groupBox3 = new GroupBox();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            labelWinter = new Label();
            dateTimePicker3 = new DateTimePicker();
            dateTimePicker4 = new DateTimePicker();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // labelVersionAccess
            // 
            labelVersionAccess.AutoSize = true;
            labelVersionAccess.Location = new Point(28, 72);
            labelVersionAccess.Name = "labelVersionAccess";
            labelVersionAccess.Size = new Size(94, 20);
            labelVersionAccess.TabIndex = 0;
            labelVersionAccess.Text = "Версия Core";
            // 
            // textBoxVersionAccess
            // 
            textBoxVersionAccess.Location = new Point(240, 65);
            textBoxVersionAccess.Name = "textBoxVersionAccess";
            textBoxVersionAccess.Size = new Size(214, 27);
            textBoxVersionAccess.TabIndex = 1;
            // 
            // labelMeasurementValues
            // 
            labelMeasurementValues.AutoSize = true;
            labelMeasurementValues.Location = new Point(28, 106);
            labelMeasurementValues.Name = "labelMeasurementValues";
            labelMeasurementValues.Size = new Size(201, 20);
            labelMeasurementValues.TabIndex = 2;
            labelMeasurementValues.Text = "Версия Measurement-Values";
            // 
            // textBoxMeasurementValues
            // 
            textBoxMeasurementValues.Location = new Point(240, 99);
            textBoxMeasurementValues.Name = "textBoxMeasurementValues";
            textBoxMeasurementValues.Size = new Size(214, 27);
            textBoxMeasurementValues.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxTypeMeasure);
            groupBox1.Controls.Add(label_TypeMeasure);
            groupBox1.Controls.Add(textBoxUIDPowerConsump);
            groupBox1.Controls.Add(labelUIDPowerConsump);
            groupBox1.Controls.Add(textBoxNameServer);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxMeasurementValues);
            groupBox1.Controls.Add(labelMeasurementValues);
            groupBox1.Controls.Add(labelVersionAccess);
            groupBox1.Controls.Add(textBoxVersionAccess);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(460, 213);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Настройки для получения данных от ОИК СК-11";
            // 
            // textBoxTypeMeasure
            // 
            textBoxTypeMeasure.Location = new Point(240, 133);
            textBoxTypeMeasure.Name = "textBoxTypeMeasure";
            textBoxTypeMeasure.Size = new Size(214, 27);
            textBoxTypeMeasure.TabIndex = 9;
            // 
            // label_TypeMeasure
            // 
            label_TypeMeasure.AutoSize = true;
            label_TypeMeasure.Location = new Point(28, 140);
            label_TypeMeasure.Name = "label_TypeMeasure";
            label_TypeMeasure.Size = new Size(117, 20);
            label_TypeMeasure.TabIndex = 8;
            label_TypeMeasure.Text = "Тип измерения";
            // 
            // textBoxUIDPowerConsump
            // 
            textBoxUIDPowerConsump.Location = new Point(240, 31);
            textBoxUIDPowerConsump.Name = "textBoxUIDPowerConsump";
            textBoxUIDPowerConsump.Size = new Size(214, 27);
            textBoxUIDPowerConsump.TabIndex = 7;
            // 
            // labelUIDPowerConsump
            // 
            labelUIDPowerConsump.AutoSize = true;
            labelUIDPowerConsump.Location = new Point(28, 38);
            labelUIDPowerConsump.Name = "labelUIDPowerConsump";
            labelUIDPowerConsump.Size = new Size(206, 20);
            labelUIDPowerConsump.TabIndex = 6;
            labelUIDPowerConsump.Text = "UID потребления мощности";
            // 
            // textBoxNameServer
            // 
            textBoxNameServer.Location = new Point(240, 167);
            textBoxNameServer.Name = "textBoxNameServer";
            textBoxNameServer.Size = new Size(214, 27);
            textBoxNameServer.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 174);
            label1.Name = "label1";
            label1.Size = new Size(177, 20);
            label1.TabIndex = 4;
            label1.Text = "Наименование сервера";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(labelPowerSystem);
            groupBox2.Controls.Add(label_InitPower);
            groupBox2.Controls.Add(textBoxInitPower);
            groupBox2.Location = new Point(12, 370);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(460, 114);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Исходные данные для расчёта потребления мощности";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(235, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(214, 28);
            comboBox1.TabIndex = 3;
            // 
            // labelPowerSystem
            // 
            labelPowerSystem.AutoSize = true;
            labelPowerSystem.Location = new Point(28, 73);
            labelPowerSystem.Name = "labelPowerSystem";
            labelPowerSystem.Size = new Size(115, 20);
            labelPowerSystem.TabIndex = 2;
            labelPowerSystem.Text = "Энергосистема";
            // 
            // label_InitPower
            // 
            label_InitPower.AutoSize = true;
            label_InitPower.Location = new Point(28, 39);
            label_InitPower.Name = "label_InitPower";
            label_InitPower.Size = new Size(151, 20);
            label_InitPower.TabIndex = 0;
            label_InitPower.Text = "Исходная мощность";
            // 
            // textBoxInitPower
            // 
            textBoxInitPower.Location = new Point(235, 32);
            textBoxInitPower.Name = "textBoxInitPower";
            textBoxInitPower.Size = new Size(219, 27);
            textBoxInitPower.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(12, 490);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(441, 29);
            buttonOK.TabIndex = 7;
            buttonOK.Text = "ОК";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(dateTimePicker3);
            groupBox3.Controls.Add(dateTimePicker4);
            groupBox3.Controls.Add(dateTimePicker2);
            groupBox3.Controls.Add(dateTimePicker1);
            groupBox3.Controls.Add(labelWinter);
            groupBox3.Location = new Point(12, 231);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(460, 133);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Интервал времени";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(15, 84);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(214, 27);
            dateTimePicker2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(15, 51);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(214, 27);
            dateTimePicker1.TabIndex = 7;
            // 
            // labelWinter
            // 
            labelWinter.AutoSize = true;
            labelWinter.Location = new Point(58, 28);
            labelWinter.Name = "labelWinter";
            labelWinter.Size = new Size(121, 20);
            labelWinter.TabIndex = 6;
            labelWinter.Text = "Зимние месяцы";
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Location = new Point(240, 84);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(214, 27);
            dateTimePicker3.TabIndex = 10;
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.Location = new Point(240, 51);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new Size(214, 27);
            dateTimePicker4.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(288, 28);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 11;
            label2.Text = "Летние месяцы";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 540);
            Controls.Add(groupBox3);
            Controls.Add(buttonOK);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelVersionAccess;
        private TextBox textBoxVersionAccess;
        private Label labelMeasurementValues;
        private TextBox textBoxMeasurementValues;
        private GroupBox groupBox1;
        private TextBox textBoxNameServer;
        private Label label1;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private Label labelPowerSystem;
        private Label label_InitPower;
        private TextBox textBoxInitPower;
        private Button buttonOK;
        private TextBox textBoxUIDPowerConsump;
        private Label labelUIDPowerConsump;
        private TextBox textBoxTypeMeasure;
        private Label label_TypeMeasure;
        private GroupBox groupBox3;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label labelWinter;
        private Label label2;
        private DateTimePicker dateTimePicker3;
        private DateTimePicker dateTimePicker4;
    }
}