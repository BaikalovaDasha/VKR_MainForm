﻿namespace MainForm
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
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            MenuItemStartCalculation = new ToolStripMenuItem();
            остановитьРасчётToolStripMenuItem = new ToolStripMenuItem();
            tabPage3 = new TabPage();
            dataGridViewKoefAverage = new DataGridView();
            averageOutputPowerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            averageOutputPerHourBindingSource1 = new BindingSource(components);
            dataGridViewSPP = new DataGridView();
            nameSPPDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            averageOutputDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            installedCapacityDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            koefAveragepowerSPPDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            solarPowerPlantBindingSource3 = new BindingSource(components);
            dataGridView_TimeForKoefAverage = new DataGridView();
            timeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            averageOutputPerHourBindingSource = new BindingSource(components);
            solarPowerPlantBindingSource1 = new BindingSource(components);
            tabPage2 = new TabPage();
            editingTable = new ToolStrip();
            AddNewSPP = new ToolStripButton();
            DeleteSPP = new ToolStripButton();
            dataGridView1 = new DataGridView();
            nameSPPDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusSPPDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nodeSPPDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            powerSystemDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            installedCapacityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            uIDsppDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            solarPowerPlantBindingSource = new BindingSource(components);
            tabControl1 = new TabControl();
            solarPowerPlantBindingSource2 = new BindingSource(components);
            toolStrip1.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKoefAverage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)averageOutputPerHourBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSPP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_TimeForKoefAverage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)averageOutputPerHourBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource1).BeginInit();
            tabPage2.SuspendLayout();
            editingTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource).BeginInit();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource2).BeginInit();
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
            MenuItemStartCalculation.Size = new Size(223, 26);
            MenuItemStartCalculation.Text = "Начать расчёт";
            MenuItemStartCalculation.Click += MenuItemStartCalculation_Click;
            // 
            // остановитьРасчётToolStripMenuItem
            // 
            остановитьРасчётToolStripMenuItem.Name = "остановитьРасчётToolStripMenuItem";
            остановитьРасчётToolStripMenuItem.Size = new Size(223, 26);
            остановитьРасчётToolStripMenuItem.Text = "Остановить расчёт";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridViewKoefAverage);
            tabPage3.Controls.Add(dataGridViewSPP);
            tabPage3.Controls.Add(dataGridView_TimeForKoefAverage);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(943, 419);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Результаты расчёта";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewKoefAverage
            // 
            dataGridViewKoefAverage.AllowUserToAddRows = false;
            dataGridViewKoefAverage.AllowUserToDeleteRows = false;
            dataGridViewKoefAverage.AutoGenerateColumns = false;
            dataGridViewKoefAverage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKoefAverage.Columns.AddRange(new DataGridViewColumn[] { averageOutputPowerDataGridViewTextBoxColumn });
            dataGridViewKoefAverage.DataSource = averageOutputPerHourBindingSource1;
            dataGridViewKoefAverage.Location = new Point(720, 22);
            dataGridViewKoefAverage.Name = "dataGridViewKoefAverage";
            dataGridViewKoefAverage.ReadOnly = true;
            dataGridViewKoefAverage.RowHeadersWidth = 51;
            dataGridViewKoefAverage.RowTemplate.Height = 29;
            dataGridViewKoefAverage.Size = new Size(167, 274);
            dataGridViewKoefAverage.TabIndex = 2;
            // 
            // averageOutputPowerDataGridViewTextBoxColumn
            // 
            averageOutputPowerDataGridViewTextBoxColumn.DataPropertyName = "AverageOutputPower";
            averageOutputPowerDataGridViewTextBoxColumn.HeaderText = "k_СЭС ср, о.е.";
            averageOutputPowerDataGridViewTextBoxColumn.MinimumWidth = 6;
            averageOutputPowerDataGridViewTextBoxColumn.Name = "averageOutputPowerDataGridViewTextBoxColumn";
            averageOutputPowerDataGridViewTextBoxColumn.ReadOnly = true;
            averageOutputPowerDataGridViewTextBoxColumn.Width = 125;
            // 
            // averageOutputPerHourBindingSource1
            // 
            averageOutputPerHourBindingSource1.DataSource = typeof(Model.AverageOutputPerHour);
            // 
            // dataGridViewSPP
            // 
            dataGridViewSPP.AllowUserToAddRows = false;
            dataGridViewSPP.AllowUserToDeleteRows = false;
            dataGridViewSPP.AutoGenerateColumns = false;
            dataGridViewSPP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSPP.Columns.AddRange(new DataGridViewColumn[] { nameSPPDataGridViewTextBoxColumn1, averageOutputDataGridViewTextBoxColumn, installedCapacityDataGridViewTextBoxColumn1, koefAveragepowerSPPDataGridViewTextBoxColumn });
            dataGridViewSPP.DataSource = solarPowerPlantBindingSource3;
            dataGridViewSPP.Location = new Point(186, 22);
            dataGridViewSPP.Name = "dataGridViewSPP";
            dataGridViewSPP.ReadOnly = true;
            dataGridViewSPP.RowHeadersWidth = 51;
            dataGridViewSPP.RowTemplate.Height = 29;
            dataGridViewSPP.Size = new Size(528, 274);
            dataGridViewSPP.TabIndex = 1;
            // 
            // nameSPPDataGridViewTextBoxColumn1
            // 
            nameSPPDataGridViewTextBoxColumn1.DataPropertyName = "NameSPP";
            nameSPPDataGridViewTextBoxColumn1.HeaderText = "Наименование СЭС";
            nameSPPDataGridViewTextBoxColumn1.MinimumWidth = 6;
            nameSPPDataGridViewTextBoxColumn1.Name = "nameSPPDataGridViewTextBoxColumn1";
            nameSPPDataGridViewTextBoxColumn1.ReadOnly = true;
            nameSPPDataGridViewTextBoxColumn1.Width = 125;
            // 
            // averageOutputDataGridViewTextBoxColumn
            // 
            averageOutputDataGridViewTextBoxColumn.DataPropertyName = "AverageOutput";
            averageOutputDataGridViewTextBoxColumn.HeaderText = "Средняя выработка, МВт";
            averageOutputDataGridViewTextBoxColumn.MinimumWidth = 6;
            averageOutputDataGridViewTextBoxColumn.Name = "averageOutputDataGridViewTextBoxColumn";
            averageOutputDataGridViewTextBoxColumn.ReadOnly = true;
            averageOutputDataGridViewTextBoxColumn.Width = 125;
            // 
            // installedCapacityDataGridViewTextBoxColumn1
            // 
            installedCapacityDataGridViewTextBoxColumn1.DataPropertyName = "InstalledCapacity";
            installedCapacityDataGridViewTextBoxColumn1.HeaderText = "Установленная мощность СЭС";
            installedCapacityDataGridViewTextBoxColumn1.MinimumWidth = 6;
            installedCapacityDataGridViewTextBoxColumn1.Name = "installedCapacityDataGridViewTextBoxColumn1";
            installedCapacityDataGridViewTextBoxColumn1.ReadOnly = true;
            installedCapacityDataGridViewTextBoxColumn1.Width = 125;
            // 
            // koefAveragepowerSPPDataGridViewTextBoxColumn
            // 
            koefAveragepowerSPPDataGridViewTextBoxColumn.DataPropertyName = "KoefAveragepowerSPP";
            koefAveragepowerSPPDataGridViewTextBoxColumn.HeaderText = "К_сэс, о.е.";
            koefAveragepowerSPPDataGridViewTextBoxColumn.MinimumWidth = 6;
            koefAveragepowerSPPDataGridViewTextBoxColumn.Name = "koefAveragepowerSPPDataGridViewTextBoxColumn";
            koefAveragepowerSPPDataGridViewTextBoxColumn.ReadOnly = true;
            koefAveragepowerSPPDataGridViewTextBoxColumn.Width = 125;
            // 
            // solarPowerPlantBindingSource3
            // 
            solarPowerPlantBindingSource3.DataSource = typeof(Model.SolarPowerPlant);
            // 
            // dataGridView_TimeForKoefAverage
            // 
            dataGridView_TimeForKoefAverage.AllowUserToAddRows = false;
            dataGridView_TimeForKoefAverage.AllowUserToDeleteRows = false;
            dataGridView_TimeForKoefAverage.AutoGenerateColumns = false;
            dataGridView_TimeForKoefAverage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_TimeForKoefAverage.Columns.AddRange(new DataGridViewColumn[] { timeDataGridViewTextBoxColumn });
            dataGridView_TimeForKoefAverage.DataSource = averageOutputPerHourBindingSource;
            dataGridView_TimeForKoefAverage.Location = new Point(26, 22);
            dataGridView_TimeForKoefAverage.Name = "dataGridView_TimeForKoefAverage";
            dataGridView_TimeForKoefAverage.ReadOnly = true;
            dataGridView_TimeForKoefAverage.RowHeadersWidth = 51;
            dataGridView_TimeForKoefAverage.RowTemplate.Height = 29;
            dataGridView_TimeForKoefAverage.Size = new Size(154, 274);
            dataGridView_TimeForKoefAverage.TabIndex = 0;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            timeDataGridViewTextBoxColumn.HeaderText = "Время, ч";
            timeDataGridViewTextBoxColumn.MinimumWidth = 6;
            timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            timeDataGridViewTextBoxColumn.ReadOnly = true;
            timeDataGridViewTextBoxColumn.Width = 125;
            // 
            // averageOutputPerHourBindingSource
            // 
            averageOutputPerHourBindingSource.DataSource = typeof(Model.AverageOutputPerHour);
            // 
            // solarPowerPlantBindingSource1
            // 
            solarPowerPlantBindingSource1.DataSource = typeof(Model.SolarPowerPlant);
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
            editingTable.Items.AddRange(new ToolStripItem[] { AddNewSPP, DeleteSPP });
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
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameSPPDataGridViewTextBoxColumn, statusSPPDataGridViewTextBoxColumn, nodeSPPDataGridViewTextBoxColumn, powerSystemDataGridViewTextBoxColumn, installedCapacityDataGridViewTextBoxColumn, uIDsppDataGridViewTextBoxColumn });
            dataGridView1.DataSource = solarPowerPlantBindingSource;
            dataGridView1.Location = new Point(3, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(937, 380);
            dataGridView1.TabIndex = 0;
            // 
            // nameSPPDataGridViewTextBoxColumn
            // 
            nameSPPDataGridViewTextBoxColumn.DataPropertyName = "NameSPP";
            nameSPPDataGridViewTextBoxColumn.HeaderText = "Наименование СЭС";
            nameSPPDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameSPPDataGridViewTextBoxColumn.Name = "nameSPPDataGridViewTextBoxColumn";
            nameSPPDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusSPPDataGridViewTextBoxColumn
            // 
            statusSPPDataGridViewTextBoxColumn.DataPropertyName = "StatusSPP";
            statusSPPDataGridViewTextBoxColumn.HeaderText = "Статус СЭС";
            statusSPPDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusSPPDataGridViewTextBoxColumn.Name = "statusSPPDataGridViewTextBoxColumn";
            statusSPPDataGridViewTextBoxColumn.Width = 125;
            // 
            // nodeSPPDataGridViewTextBoxColumn
            // 
            nodeSPPDataGridViewTextBoxColumn.DataPropertyName = "NodeSPP";
            nodeSPPDataGridViewTextBoxColumn.HeaderText = "Номер агрегата в РМ";
            nodeSPPDataGridViewTextBoxColumn.MinimumWidth = 6;
            nodeSPPDataGridViewTextBoxColumn.Name = "nodeSPPDataGridViewTextBoxColumn";
            nodeSPPDataGridViewTextBoxColumn.Width = 125;
            // 
            // powerSystemDataGridViewTextBoxColumn
            // 
            powerSystemDataGridViewTextBoxColumn.DataPropertyName = "PowerSystem";
            powerSystemDataGridViewTextBoxColumn.HeaderText = "Энергосистема";
            powerSystemDataGridViewTextBoxColumn.MinimumWidth = 6;
            powerSystemDataGridViewTextBoxColumn.Name = "powerSystemDataGridViewTextBoxColumn";
            powerSystemDataGridViewTextBoxColumn.Width = 125;
            // 
            // installedCapacityDataGridViewTextBoxColumn
            // 
            installedCapacityDataGridViewTextBoxColumn.DataPropertyName = "InstalledCapacity";
            installedCapacityDataGridViewTextBoxColumn.HeaderText = "Установленная мощность СЭС";
            installedCapacityDataGridViewTextBoxColumn.MinimumWidth = 6;
            installedCapacityDataGridViewTextBoxColumn.Name = "installedCapacityDataGridViewTextBoxColumn";
            installedCapacityDataGridViewTextBoxColumn.Width = 125;
            // 
            // uIDsppDataGridViewTextBoxColumn
            // 
            uIDsppDataGridViewTextBoxColumn.DataPropertyName = "UIDspp";
            uIDsppDataGridViewTextBoxColumn.HeaderText = "UID СЭС в ОИК";
            uIDsppDataGridViewTextBoxColumn.MinimumWidth = 6;
            uIDsppDataGridViewTextBoxColumn.Name = "uIDsppDataGridViewTextBoxColumn";
            uIDsppDataGridViewTextBoxColumn.Width = 125;
            // 
            // solarPowerPlantBindingSource
            // 
            solarPowerPlantBindingSource.DataSource = typeof(Model.SolarPowerPlant);
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
            // solarPowerPlantBindingSource2
            // 
            solarPowerPlantBindingSource2.DataSource = typeof(Model.SolarPowerPlant);
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
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewKoefAverage).EndInit();
            ((System.ComponentModel.ISupportInitialize)averageOutputPerHourBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSPP).EndInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_TimeForKoefAverage).EndInit();
            ((System.ComponentModel.ISupportInitialize)averageOutputPerHourBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            editingTable.ResumeLayout(false);
            editingTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource).EndInit();
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)solarPowerPlantBindingSource2).EndInit();
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
        private DataGridViewTextBoxColumn numberSPPDataGridViewTextBoxColumn;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem MenuItemStartCalculation;
        private ToolStripMenuItem остановитьРасчётToolStripMenuItem;
        private DataGridViewTextBoxColumn nameSPPDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusSPPDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nodeSPPDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn powerSystemDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn installedCapacityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn uIDsppDataGridViewTextBoxColumn;
        private BindingSource solarPowerPlantBindingSource;
        private BindingSource solarPowerPlantBindingSource1;
        private DataGridView dataGridViewKoefAverage;
        private DataGridView dataGridViewSPP;
        private DataGridView dataGridView_TimeForKoefAverage;
        private DataGridViewTextBoxColumn averageOutputPowerDataGridViewTextBoxColumn;
        private BindingSource averageOutputPerHourBindingSource1;
        private DataGridViewTextBoxColumn nameSPPDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn averageOutputDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn installedCapacityDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn koefAveragepowerSPPDataGridViewTextBoxColumn;
        private BindingSource solarPowerPlantBindingSource3;
        private DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private BindingSource averageOutputPerHourBindingSource;
        private BindingSource solarPowerPlantBindingSource2;
    }
}