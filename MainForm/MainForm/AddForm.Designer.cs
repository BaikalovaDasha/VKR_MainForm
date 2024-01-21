namespace MainForm
{
    partial class AddForm
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
            comboBoxStatusSPP = new ComboBox();
            labelStatusSPP = new Label();
            groupBox1 = new GroupBox();
            textBoxUIDSPP = new TextBox();
            labelUIDSPP = new Label();
            textBoxInstallCapacity = new TextBox();
            labelInstallCapacity = new Label();
            textBoxNumSPP = new TextBox();
            labelNumSPP = new Label();
            textBoxNameSPP = new TextBox();
            labelNameSPP = new Label();
            labelPowerSystem = new Label();
            comboBoxPowerSystem = new ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button_AddSPP = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxStatusSPP
            // 
            comboBoxStatusSPP.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusSPP.FormattingEnabled = true;
            comboBoxStatusSPP.Location = new Point(264, 71);
            comboBoxStatusSPP.Name = "comboBoxStatusSPP";
            comboBoxStatusSPP.Size = new Size(184, 28);
            comboBoxStatusSPP.TabIndex = 0;
            comboBoxStatusSPP.SelectedIndexChanged += StatusSPP_SelectedIndexChanged;
            // 
            // labelStatusSPP
            // 
            labelStatusSPP.AutoSize = true;
            labelStatusSPP.Location = new Point(6, 74);
            labelStatusSPP.Name = "labelStatusSPP";
            labelStatusSPP.Size = new Size(154, 20);
            labelStatusSPP.TabIndex = 1;
            labelStatusSPP.Text = "Выберите статус СЭС";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxUIDSPP);
            groupBox1.Controls.Add(labelUIDSPP);
            groupBox1.Controls.Add(textBoxInstallCapacity);
            groupBox1.Controls.Add(labelInstallCapacity);
            groupBox1.Controls.Add(textBoxNumSPP);
            groupBox1.Controls.Add(labelNumSPP);
            groupBox1.Controls.Add(textBoxNameSPP);
            groupBox1.Controls.Add(labelNameSPP);
            groupBox1.Controls.Add(labelPowerSystem);
            groupBox1.Controls.Add(comboBoxPowerSystem);
            groupBox1.Controls.Add(comboBoxStatusSPP);
            groupBox1.Controls.Add(labelStatusSPP);
            groupBox1.Location = new Point(15, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(472, 280);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Параметры СЭС";
            // 
            // textBoxUIDSPP
            // 
            textBoxUIDSPP.BorderStyle = BorderStyle.FixedSingle;
            textBoxUIDSPP.Location = new Point(264, 235);
            textBoxUIDSPP.Name = "textBoxUIDSPP";
            textBoxUIDSPP.Size = new Size(184, 27);
            textBoxUIDSPP.TabIndex = 12;
            // 
            // labelUIDSPP
            // 
            labelUIDSPP.AutoSize = true;
            labelUIDSPP.Location = new Point(7, 242);
            labelUIDSPP.Name = "labelUIDSPP";
            labelUIDSPP.Size = new Size(181, 20);
            labelUIDSPP.TabIndex = 11;
            labelUIDSPP.Text = "Введите UID СЭС в СК-11";
            // 
            // textBoxInstallCapacity
            // 
            textBoxInstallCapacity.BorderStyle = BorderStyle.FixedSingle;
            textBoxInstallCapacity.Location = new Point(264, 194);
            textBoxInstallCapacity.Name = "textBoxInstallCapacity";
            textBoxInstallCapacity.Size = new Size(184, 27);
            textBoxInstallCapacity.TabIndex = 10;
            textBoxInstallCapacity.KeyPress += ControlValueDouble_KeyPress;
            // 
            // labelInstallCapacity
            // 
            labelInstallCapacity.AutoSize = true;
            labelInstallCapacity.Location = new Point(7, 201);
            labelInstallCapacity.Name = "labelInstallCapacity";
            labelInstallCapacity.Size = new Size(251, 20);
            labelInstallCapacity.TabIndex = 9;
            labelInstallCapacity.Text = "Введите установленную мощность";
            // 
            // textBoxNumSPP
            // 
            textBoxNumSPP.BorderStyle = BorderStyle.FixedSingle;
            textBoxNumSPP.Location = new Point(264, 112);
            textBoxNumSPP.Name = "textBoxNumSPP";
            textBoxNumSPP.Size = new Size(184, 27);
            textBoxNumSPP.TabIndex = 8;
            textBoxNumSPP.KeyPress += ControlValueInt_KeyPress;
            // 
            // labelNumSPP
            // 
            labelNumSPP.AutoSize = true;
            labelNumSPP.Location = new Point(6, 119);
            labelNumSPP.Name = "labelNumSPP";
            labelNumSPP.Size = new Size(186, 20);
            labelNumSPP.TabIndex = 7;
            labelNumSPP.Text = "Введите номер узла в РМ";
            // 
            // textBoxNameSPP
            // 
            textBoxNameSPP.BorderStyle = BorderStyle.FixedSingle;
            textBoxNameSPP.Location = new Point(264, 30);
            textBoxNameSPP.Name = "textBoxNameSPP";
            textBoxNameSPP.Size = new Size(184, 27);
            textBoxNameSPP.TabIndex = 6;
            // 
            // labelNameSPP
            // 
            labelNameSPP.AutoSize = true;
            labelNameSPP.Location = new Point(6, 37);
            labelNameSPP.Name = "labelNameSPP";
            labelNameSPP.Size = new Size(205, 20);
            labelNameSPP.TabIndex = 5;
            labelNameSPP.Text = "Введите наименование СЭС";
            // 
            // labelPowerSystem
            // 
            labelPowerSystem.AutoSize = true;
            labelPowerSystem.Location = new Point(6, 161);
            labelPowerSystem.Name = "labelPowerSystem";
            labelPowerSystem.Size = new Size(187, 20);
            labelPowerSystem.TabIndex = 3;
            labelPowerSystem.Text = "Выберите Энергосистему";
            // 
            // comboBoxPowerSystem
            // 
            comboBoxPowerSystem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPowerSystem.FormattingEnabled = true;
            comboBoxPowerSystem.Location = new Point(264, 153);
            comboBoxPowerSystem.Name = "comboBoxPowerSystem";
            comboBoxPowerSystem.Size = new Size(184, 28);
            comboBoxPowerSystem.TabIndex = 4;
            comboBoxPowerSystem.SelectedIndexChanged += PowerSystem_SelectedIndexChanged;
            // 
            // button_AddSPP
            // 
            button_AddSPP.Location = new Point(70, 298);
            button_AddSPP.Name = "button_AddSPP";
            button_AddSPP.Size = new Size(369, 29);
            button_AddSPP.TabIndex = 5;
            button_AddSPP.Text = "Добавить СЭС";
            button_AddSPP.UseVisualStyleBackColor = true;
            button_AddSPP.Click += Button_AddSPP_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 339);
            Controls.Add(button_AddSPP);
            Controls.Add(groupBox1);
            Name = "AddForm";
            Text = "Добавить СЭС";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxStatusSPP;
        private Label labelStatusSPP;
        private GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label labelPowerSystem;
        private ComboBox comboBoxPowerSystem;
        private Button button_AddSPP;
        private TextBox textBoxUIDSPP;
        private Label labelUIDSPP;
        private TextBox textBoxInstallCapacity;
        private Label labelInstallCapacity;
        private TextBox textBoxNumSPP;
        private Label labelNumSPP;
        private TextBox textBoxNameSPP;
        private Label labelNameSPP;
    }
}