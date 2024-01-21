namespace MainForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            LoadFile = new ToolStripMenuItem();
            LoadCalaulModel = new ToolStripMenuItem();
            LoadTableSPP = new ToolStripMenuItem();
            LoadFileExcel = new ToolStripMenuItem();
            LoadKoefandTempExcel = new ToolStripMenuItem();
            LoadKoefPoerPSExcel = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            Save_TableSPP = new ToolStripMenuItem();
            tabPage3 = new TabPage();
            tabPage2 = new TabPage();
            editingTable = new ToolStrip();
            AddNewSPP = new ToolStripButton();
            DeleteSPP = new ToolStripButton();
            OK = new ToolStripButton();
            dataGridView1 = new DataGridView();
            tabControl1 = new TabControl();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            MenuItemStartCalculation = new ToolStripMenuItem();
            остановитьРасчётToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            tabPage2.SuspendLayout();
            editingTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripDropDownButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(951, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { LoadFile, сохранитьToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(59, 24);
            toolStripDropDownButton1.Text = "Файл";
            // 
            // LoadFile
            // 
            LoadFile.DropDownItems.AddRange(new ToolStripItem[] { LoadCalaulModel, LoadTableSPP, LoadFileExcel });
            LoadFile.Name = "LoadFile";
            LoadFile.Size = new Size(224, 26);
            LoadFile.Text = "Загрузить";
            // 
            // LoadCalaulModel
            // 
            LoadCalaulModel.Name = "LoadCalaulModel";
            LoadCalaulModel.Size = new Size(221, 26);
            LoadCalaulModel.Text = "Расчётную модель";
            // 
            // LoadTableSPP
            // 
            LoadTableSPP.Name = "LoadTableSPP";
            LoadTableSPP.Size = new Size(221, 26);
            LoadTableSPP.Text = "Таблицу СЭС";
            LoadTableSPP.Click += LoadTableSPP_Click;
            // 
            // LoadFileExcel
            // 
            LoadFileExcel.DropDownItems.AddRange(new ToolStripItem[] { LoadKoefandTempExcel, LoadKoefPoerPSExcel });
            LoadFileExcel.Name = "LoadFileExcel";
            LoadFileExcel.Size = new Size(221, 26);
            LoadFileExcel.Text = "Файлы Excel";
            // 
            // LoadKoefandTempExcel
            // 
            LoadKoefandTempExcel.Name = "LoadKoefandTempExcel";
            LoadKoefandTempExcel.Size = new Size(651, 26);
            LoadKoefandTempExcel.Text = "Значение коэффициентов и температур наружного воздуха ЭС";
            // 
            // LoadKoefPoerPSExcel
            // 
            LoadKoefPoerPSExcel.Name = "LoadKoefPoerPSExcel";
            LoadKoefPoerPSExcel.Size = new Size(651, 26);
            LoadKoefPoerPSExcel.Text = "Коэффициенты зависимости изменения максимума потребления мощности ЭС";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Save_TableSPP });
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(224, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // Save_TableSPP
            // 
            Save_TableSPP.Name = "Save_TableSPP";
            Save_TableSPP.Size = new Size(181, 26);
            Save_TableSPP.Text = "Таблицу СЭС";
            Save_TableSPP.Click += Save_TableSPP_Click;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(943, 419);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Результаты расчёта";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(editingTable);
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(943, 419);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Таблица СЭС";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // editingTable
            // 
            editingTable.ImageScalingSize = new Size(20, 20);
            editingTable.Items.AddRange(new ToolStripItem[] { AddNewSPP, DeleteSPP, OK });
            editingTable.Location = new Point(3, 3);
            editingTable.Name = "editingTable";
            editingTable.Size = new Size(937, 27);
            editingTable.TabIndex = 1;
            editingTable.Text = "toolStrip2";
            // 
            // AddNewSPP
            // 
            AddNewSPP.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AddNewSPP.Image = (Image)resources.GetObject("AddNewSPP.Image");
            AddNewSPP.ImageTransparentColor = Color.Magenta;
            AddNewSPP.Name = "AddNewSPP";
            AddNewSPP.Size = new Size(29, 24);
            AddNewSPP.Text = "toolStripButton1";
            AddNewSPP.Click += AddNewSPP_Click;
            // 
            // DeleteSPP
            // 
            DeleteSPP.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DeleteSPP.Image = (Image)resources.GetObject("DeleteSPP.Image");
            DeleteSPP.ImageTransparentColor = Color.Magenta;
            DeleteSPP.Name = "DeleteSPP";
            DeleteSPP.Size = new Size(29, 24);
            DeleteSPP.Text = "toolStripButton2";
            DeleteSPP.Click += DeleteSPP_Click;
            // 
            // OK
            // 
            OK.DisplayStyle = ToolStripItemDisplayStyle.Image;
            OK.Image = (Image)resources.GetObject("OK.Image");
            OK.ImageTransparentColor = Color.Magenta;
            OK.Name = "OK";
            OK.Size = new Size(29, 24);
            OK.Text = "toolStripButton1";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(937, 380);
            dataGridView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.ShowToolTips = true;
            tabControl1.Size = new Size(951, 452);
            tabControl1.TabIndex = 0;
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { MenuItemStartCalculation, остановитьРасчётToolStripMenuItem });
            toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(79, 24);
            toolStripDropDownButton2.Text = "Расчёты";
            // 
            // MenuItemStartCalculation
            // 
            MenuItemStartCalculation.Name = "MenuItemStartCalculation";
            MenuItemStartCalculation.Size = new Size(224, 26);
            MenuItemStartCalculation.Text = "Начать расчёт";
            MenuItemStartCalculation.Click += MenuItemStartCalculation_Click;
            // 
            // остановитьРасчётToolStripMenuItem
            // 
            остановитьРасчётToolStripMenuItem.Name = "остановитьРасчётToolStripMenuItem";
            остановитьРасчётToolStripMenuItem.Size = new Size(224, 26);
            остановитьРасчётToolStripMenuItem.Text = "Остановить расчёт";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 481);
            Controls.Add(toolStrip1);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Расчёт доли СЭС";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            editingTable.ResumeLayout(false);
            editingTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem LoadFile;
        private ToolStripMenuItem LoadCalaulModel;
        private ToolStripMenuItem LoadTableSPP;
        private ToolStripMenuItem LoadFileExcel;
        private ToolStripMenuItem LoadKoefandTempExcel;
        private ToolStripMenuItem LoadKoefPoerPSExcel;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem Save_TableSPP;
        private TabPage tabPage3;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private TabControl tabControl1;
        private ToolStrip editingTable;
        private ToolStripButton AddNewSPP;
        private ToolStripButton DeleteSPP;
        private ToolStripButton OK;
        private DataGridViewTextBoxColumn numberSPPDataGridViewTextBoxColumn;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem MenuItemStartCalculation;
        private ToolStripMenuItem остановитьРасчётToolStripMenuItem;
    }
}