using System.ComponentModel;
using Model;
using System.Xml.Serialization;
using System.Windows.Forms;
using CalculationModel;
using ExcelHandler;
using Microsoft.Office.Interop.Word;

namespace MainForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ������ ���������� ���.
        /// </summary>
        private BindingList<SolarPowerPlant> _sppDataList;

        /// <summary>
        /// ������ ���������� ���.
        /// </summary>
        public BindingList<SolarPowerPlant> SPPDataList
        {
            get
            {
                return _sppDataList;
            }
            set
            {
                _sppDataList = value;
            }
        }

        public BindingList<SolarPowerPlant> SPPDataListWithKoefs;

        /// <summary>
        /// ������ �������� ��� � ������������� ��������� ����������.
        /// </summary>
        public BindingList<SolarPowerPlant> ResultOutputPowerSPPCalcul;

        /// <summary>
        /// ������ ������������� ������� ��������� � ������ ���.
        /// </summary>
        public BindingList<AverageOutputPerHour> KoefDataList;

        /// <summary>
        /// ��� ������.
        /// </summary>
        private readonly XmlSerializer _serializer = new(typeof(BindingList<SolarPowerPlant>));

        /// <summary>
        /// ������ �����.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            var source = new BindingSource(SPPDataList, null);
            dataGridView1.DataSource = source;

            this.Controls.Add(tabControl1);
            tabControl1.TabPages[0].Controls.Add(dataGridViewSPP);
            tabControl1.TabPages[1].Controls.Add(dataGridViewSPP);
            tabControl1.TabPages[1].Controls.Add(dataGridView_TimeForKoefAverage);
            tabControl1.TabPages[1].Controls.Add(dataGridViewKoefAverage);
            tabControl1.TabPages[1].Controls.Add(dataGridView2);

            // Your code
            foreach (TabPage _Page in tabControl1.TabPages)
            {
                _Page.AutoScroll = true;
                //_Page.AutoScrollMargin = new System.Drawing.Size(20, 20);
                //_Page.AutoScrollMinSize = new System.Drawing.Size(_Page.Width, _Page.Height);
            }
        }

        /// <summary>
        /// ���������� ������� ��� � JSON ����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_TableSPP_Click(object sender, EventArgs e)
        {
            if (SPPDataList.Count == 0)
            {
                MessageBox.Show("����������� ������ ��� ����������.",
                    "������ �� ���������", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "����� (*.json)|*.json"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog.FileName.ToString();

                using (FileStream file = File.Create(path))
                {
                    _serializer.Serialize(file, SPPDataList);
                }
                MessageBox.Show("���� ������� �������.",
                    "���������� ���������", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// �������� �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadTableSPP_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "����� (*.json)|*.json"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var path = openFileDialog.FileName.ToString();

            try
            {
                using (var file = new StreamReader(path))
                {
                    SPPDataList = (BindingList<SolarPowerPlant>)_serializer.Deserialize(file);
                }

                dataGridView1.DataSource = SPPDataList;
                dataGridView1.CurrentCell = null;
                MessageBox.Show("���� ������� ��������.", "�������� ���������",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("�� ������� ��������� ����.\n" +
                    "���� �������� ��� �� ������������� �������.",
                    "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// �������� ��� �������� �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            SPPDataList = new BindingList<SolarPowerPlant>();
            CreateTable(SPPDataList, dataGridView1);
        }

        /// <summary>
        /// �������� ������� DataGrid.
        /// </summary>
        /// <param name="sppList">������ ���.</param>
        /// <param name="dataGridView">������� ���.</param>
        public static void CreateTable(BindingList<SolarPowerPlant> sppList,
            DataGridView dataGridView)
        {
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersVisible = false;

            var source = new BindingSource(sppList, null);
            dataGridView.DataSource = source;

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView.ColumnHeadersHeight = 45;

            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

        }

        /// <summary>
        /// ��������� ������ ����������� ���.
        /// </summary>
        /// <returns></returns>
        public static List<SolarPowerPlant> OperSPP(BindingList<SolarPowerPlant> SPPDataList)
        {
            List<SolarPowerPlant> operSPPList = new();

            foreach (var item in SPPDataList)
            {
                if (item.StatusSPP == StatusSPP.�����������)
                {
                    operSPPList.Add(item);
                }
            }
            return operSPPList;
        }

        /// <summary>
        /// �������� ������� DataGrid.
        /// </summary>
        /// <param name="koefList">������ ���.</param>
        /// <param name="dataGridView">������� ���.</param>
        public static void CreateTableWithKoef(BindingList<AverageOutputPerHour> koefList,
            DataGridView dataGridView, BindingList<SolarPowerPlant> SPPDataList)
        {
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersVisible = false;

            var source = new BindingSource(koefList, null);
            dataGridView.DataSource = source;

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView.ColumnHeadersHeight = 45;

            dataGridView.RowTemplate.Height = 23 * OperSPP(SPPDataList).Count;
            //dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

        }

        /// <summary>
        /// ���������� ��� � �������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewSPP_Click(object sender, EventArgs e)
        {
            AddForm addForm = new();

            addForm.SPPAdded += (sender, SPPEventArgs) =>
            {
                SPPDataList.Add(((EventArgsAdded)SPPEventArgs).SPP);
            };

            addForm.ShowDialog(this);

        }

        /// <summary>
        /// �������� ��� �� �������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSPP_Click(object sender, EventArgs e)
        {
            var countOfRows = dataGridView1.SelectedRows.Count;

            for (int i = 0; i < countOfRows; i++)
            {
                SPPDataList.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }

        /// <summary>
        /// ������ ������� ���� ���.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemStartCalculation_Click(object sender, EventArgs e)
        {
            SettingsForm form = new(this)
            {
                solarPowerPlant = SPPDataList
            };
            form.ShowDialog();

            CreateTable(SPPDataListWithKoefs, dataGridViewSPP);
            CreateTableWithKoef(KoefDataList, dataGridView_TimeForKoefAverage, SPPDataList);
            CreateTableWithKoef(KoefDataList, dataGridViewKoefAverage, SPPDataList);
            CreateTable(ResultOutputPowerSPPCalcul, dataGridView2);

            tabControl1.SelectedTab = tabControl1.TabPages["TabPage3"];
        }

        /// <summary>
        /// �������� ��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadCalaulModel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// �������� ���������� ��� ����� excel �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFileExcel_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadFileExcel.Text = folderBrowserDialog1.SelectedPath;

                GetParamFromExcel _pathFile = new()
                {
                    PathFile1 = LoadFileExcel.Text
                };
            }
        }

        /// <summary>
        /// ���������� ����������� � ���� Word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveResultCalculation_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application application = new();
            Document document = application.Documents.Add();

            Microsoft.Office.Interop.Word.Range range1 = document.Range(document.Content.Start, document.Content.Start);
            range1.Text = "������� 1. ����������� ������������ ������� ��������� �������� ���";
            range1.Font.Size = 14;
            range1.Font.Name = "Times New Roman";

            int rowCount = dataGridViewSPP.RowCount;
            int colCount = dataGridView_TimeForKoefAverage.ColumnCount + dataGridViewSPP.ColumnCount + dataGridViewKoefAverage.ColumnCount;

            Microsoft.Office.Interop.Word.Range range2 = document.Range(document.Content.End - 1, document.Content.End - 1);
            Table table = document.Tables.Add(range2, rowCount + 1, colCount);

            
            table.Cell(1, 1).Range.Text = "�����";
            table.Cell(1, 2).Range.Text = "������������ ���";
            table.Cell(1, 3).Range.Text = "������� ��������� ���, ���";
            table.Cell(1, 4).Range.Text = "������������� �������� ���, ���";
            table.Cell(1, 5).Range.Text = "k_���, ���";
            table.Cell(1, 6).Range.Text = "k_���_��, ���";

            for (int i = 1; i < 7; i++)
            {
                table.Cell(1, i).Range.Bold = 1;
            }

            table.Range.Font.Size = 12;
            table.Range.Font.Name = "Times New Roman";
            table.Borders.Enable = 1;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount - 2; j++)
                {
                    string str = dataGridViewSPP[j, i].Value.ToString();

                    table.Cell(i + 2, j + 2).Range.Text = str;
                }
            }

            //for (int i = 2; i < rowCount; i += rowCount / 4)
            //{
            //    table.Cell(i, 1).Merge(table.Cell(i + (rowCount / 4), 1));
            //}

            table.Cell(2, 1).Merge(table.Cell(5, 1));
            table.Cell(6, 1).Merge(table.Cell(9, 1));
            table.Cell(10, 1).Merge(table.Cell(13, 1));
            table.Cell(14, 1).Merge(table.Cell(17, 1));

            //table.Cell(2, 7).Merge(table.Cell(5, 7));
            //table.Cell(6, 7).Merge(table.Cell(9, 7));
            //table.Cell(10, 7).Merge(table.Cell(13, 7));
            //table.Cell(14, 7).Merge(table.Cell(17, 7));


            application.Quit();
        }
    }
}