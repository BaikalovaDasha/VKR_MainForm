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
            textBox1 = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            comboBox1 = new ComboBox();
            labelPowerSystem = new Label();
            label_InitPower = new Label();
            textBoxInitPower = new TextBox();
            buttonOK = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // labelVersionAccess
            // 
            labelVersionAccess.AutoSize = true;
            labelVersionAccess.Location = new Point(28, 39);
            labelVersionAccess.Name = "labelVersionAccess";
            labelVersionAccess.Size = new Size(94, 20);
            labelVersionAccess.TabIndex = 0;
            labelVersionAccess.Text = "Версия Core";
            // 
            // textBoxVersionAccess
            // 
            textBoxVersionAccess.Location = new Point(235, 32);
            textBoxVersionAccess.Name = "textBoxVersionAccess";
            textBoxVersionAccess.Size = new Size(164, 27);
            textBoxVersionAccess.TabIndex = 1;
            // 
            // labelMeasurementValues
            // 
            labelMeasurementValues.AutoSize = true;
            labelMeasurementValues.Location = new Point(28, 73);
            labelMeasurementValues.Name = "labelMeasurementValues";
            labelMeasurementValues.Size = new Size(201, 20);
            labelMeasurementValues.TabIndex = 2;
            labelMeasurementValues.Text = "Версия Measurement-Values";
            // 
            // textBoxMeasurementValues
            // 
            textBoxMeasurementValues.Location = new Point(235, 66);
            textBoxMeasurementValues.Name = "textBoxMeasurementValues";
            textBoxMeasurementValues.Size = new Size(164, 27);
            textBoxMeasurementValues.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxMeasurementValues);
            groupBox1.Controls.Add(labelMeasurementValues);
            groupBox1.Controls.Add(labelVersionAccess);
            groupBox1.Controls.Add(textBoxVersionAccess);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(441, 141);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Настройки для получения данных от ОИК СК-11";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(235, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(164, 27);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 107);
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
            groupBox2.Location = new Point(12, 172);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(441, 114);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Исходные данные для расчёта потребления мощности";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(235, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(164, 28);
            comboBox1.TabIndex = 3;
            // 
            // labelPowerSystem
            // 
            labelPowerSystem.AutoSize = true;
            labelPowerSystem.Location = new Point(28, 73);
            labelPowerSystem.Name = "labelPowerSystem";
            labelPowerSystem.Size = new Size(118, 20);
            labelPowerSystem.TabIndex = 2;
            labelPowerSystem.Text = "Энергосистемы";
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
            textBoxInitPower.Size = new Size(164, 27);
            textBoxInitPower.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(12, 304);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(441, 29);
            buttonOK.TabIndex = 7;
            buttonOK.Text = "ОК";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 350);
            Controls.Add(buttonOK);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "SettingsForm";
            Text = "SettingsForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelVersionAccess;
        private TextBox textBoxVersionAccess;
        private Label labelMeasurementValues;
        private TextBox textBoxMeasurementValues;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private Label label1;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private Label labelPowerSystem;
        private Label label_InitPower;
        private TextBox textBoxInitPower;
        private Button buttonOK;
    }
}