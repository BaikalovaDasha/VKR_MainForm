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
            components = new System.ComponentModel.Container();
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
            folderBrowserDialog1 = new FolderBrowserDialog();
            getParamFromExcelBindingSource = new BindingSource(components);
            solarPowerPlantBindingSource2 = new BindingSource(components);
            solarPowerPlantBindingSource = new BindingSource(components);
            solarPowerPlantBindingSource1 = new BindingSource(components);
            tabPage3 = new TabPage();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            uIDsppDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            installedCapacityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            powerSystemDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nodeSPPDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusSPPDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameSPPDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            numberSPPDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            editingTable = new ToolStrip();
            AddNewSPP = new ToolStripButton();
            DeleteSPP = new ToolStripButton();
            OK = new ToolStripButton();
            tabControl1 = new TabControl();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)getParamFromExcelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            editingTable.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
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
            LoadFile.Size = new Size(166, 26);
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
            сохранитьToolStripMenuItem.Size = new Size(166, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // Save_TableSPP
            // 
            Save_TableSPP.Name = "Save_TableSPP";
            Save_TableSPP.Size = new Size(181, 26);
            Save_TableSPP.Text = "Таблицу СЭС";
            Save_TableSPP.Click += Save_TableSPP_Click;
            // 
            // getParamFromExcelBindingSource
            // 
            getParamFromExcelBindingSource.DataSource = typeof(ExcelHandler.GetParamFromExcel);
            // 
            // solarPowerPlantBindingSource2
            // 
            solarPowerPlantBindingSource2.DataSource = typeof(Model.SolarPowerPlant);
            // 
            // solarPowerPlantBindingSource
            // 
            solarPowerPlantBindingSource.DataSource = typeof(Model.SolarPowerPlant);
            // 
            // solarPowerPlantBindingSource1
            // 
            solarPowerPlantBindingSource1.DataSource = typeof(Model.SolarPowerPlant);
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
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { numberSPPDataGridViewTextBoxColumn, nameSPPDataGridViewTextBoxColumn, statusSPPDataGridViewTextBoxColumn, nodeSPPDataGridViewTextBoxColumn, powerSystemDataGridViewTextBoxColumn, installedCapacityDataGridViewTextBoxColumn, uIDsppDataGridViewTextBoxColumn });
            dataGridView1.DataSource = solarPowerPlantBindingSource2;
            dataGridView1.Location = new Point(3, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(937, 380);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowPostPaint += DataGridView1_RowPostPaint;
            // 
            // uIDsppDataGridViewTextBoxColumn
            // 
            uIDsppDataGridViewTextBoxColumn.DataPropertyName = "UIDspp";
            uIDsppDataGridViewTextBoxColumn.HeaderText = "UID СЭС в ОИК";
            uIDsppDataGridViewTextBoxColumn.MinimumWidth = 6;
            uIDsppDataGridViewTextBoxColumn.Name = "uIDsppDataGridViewTextBoxColumn";
            uIDsppDataGridViewTextBoxColumn.Width = 125;
            // 
            // installedCapacityDataGridViewTextBoxColumn
            // 
            installedCapacityDataGridViewTextBoxColumn.DataPropertyName = "InstalledCapacity";
            installedCapacityDataGridViewTextBoxColumn.HeaderText = "Установленная мощность СЭС";
            installedCapacityDataGridViewTextBoxColumn.MinimumWidth = 6;
            installedCapacityDataGridViewTextBoxColumn.Name = "installedCapacityDataGridViewTextBoxColumn";
            installedCapacityDataGridViewTextBoxColumn.Width = 125;
            // 
            // powerSystemDataGridViewTextBoxColumn
            // 
            powerSystemDataGridViewTextBoxColumn.DataPropertyName = "PowerSystem";
            powerSystemDataGridViewTextBoxColumn.HeaderText = "Энергосистема";
            powerSystemDataGridViewTextBoxColumn.MinimumWidth = 6;
            powerSystemDataGridViewTextBoxColumn.Name = "powerSystemDataGridViewTextBoxColumn";
            powerSystemDataGridViewTextBoxColumn.Width = 125;
            // 
            // nodeSPPDataGridViewTextBoxColumn
            // 
            nodeSPPDataGridViewTextBoxColumn.DataPropertyName = "NodeSPP";
            nodeSPPDataGridViewTextBoxColumn.HeaderText = "Номер агрегата в РМ";
            nodeSPPDataGridViewTextBoxColumn.MinimumWidth = 6;
            nodeSPPDataGridViewTextBoxColumn.Name = "nodeSPPDataGridViewTextBoxColumn";
            nodeSPPDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusSPPDataGridViewTextBoxColumn
            // 
            statusSPPDataGridViewTextBoxColumn.DataPropertyName = "StatusSPP";
            statusSPPDataGridViewTextBoxColumn.HeaderText = "Статус СЭС";
            statusSPPDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusSPPDataGridViewTextBoxColumn.Name = "statusSPPDataGridViewTextBoxColumn";
            statusSPPDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameSPPDataGridViewTextBoxColumn
            // 
            nameSPPDataGridViewTextBoxColumn.DataPropertyName = "NameSPP";
            nameSPPDataGridViewTextBoxColumn.HeaderText = "Наименование СЭС";
            nameSPPDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameSPPDataGridViewTextBoxColumn.Name = "nameSPPDataGridViewTextBoxColumn";
            nameSPPDataGridViewTextBoxColumn.Width = 125;
            // 
            // numberSPPDataGridViewTextBoxColumn
            // 
            numberSPPDataGridViewTextBoxColumn.DataPropertyName = "NumberSPP";
            numberSPPDataGridViewTextBoxColumn.HeaderText = "№";
            numberSPPDataGridViewTextBoxColumn.MinimumWidth = 6;
            numberSPPDataGridViewTextBoxColumn.Name = "numberSPPDataGridViewTextBoxColumn";
            numberSPPDataGridViewTextBoxColumn.Width = 125;
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
            ((System.ComponentModel.ISupportInitialize)getParamFromExcelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            editingTable.ResumeLayout(false);
            editingTable.PerformLayout();
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
        private FolderBrowserDialog folderBrowserDialog1;
        private BindingSource getParamFromExcelBindingSource;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem Save_TableSPP;
        private BindingSource solarPowerPlantBindingSource;
        private BindingSource solarPowerPlantBindingSource2;
        private BindingSource solarPowerPlantBindingSource1;
        private TabPage tabPage3;
        private TabPage tabPage2;
        private ToolStrip editingTable;
        private ToolStripButton AddNewSPP;
        private ToolStripButton DeleteSPP;
        private ToolStripButton OK;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn numberSPPDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameSPPDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusSPPDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nodeSPPDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn powerSystemDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn installedCapacityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn uIDsppDataGridViewTextBoxColumn;
        private TabControl tabControl1;
    }
}