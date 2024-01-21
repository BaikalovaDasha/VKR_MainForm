using CalculationModel;
using ExcelHandler;
using System.ComponentModel;
using Model;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.Json;

namespace MainForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private BindingList<SolarPowerPlant> _sppDataList;

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

            var source = new BindingSource(_sppDataList, null);
            dataGridView1.DataSource = source;
            //string[] powerSystem = { "�������������", "�������������", "������", "�������������" };

            //ChoosEnergySystem_Combobox.Items.AddRange(new string[]
            //{
            //    powerSystem[0],
            //    powerSystem[1],
            //    powerSystem[2],
            //    powerSystem[3]
            //});
        }

        ///// <summary>
        ///// �������� ����� �������� �������� ��������.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ControlValue_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    ControlText.CheckInputDouble(e);
        //}

        ///// <summary>
        ///// ������������ �������� ����� � ����� ��� ���������� ������ � Excel.
        ///// </summary>
        ///// <returns></returns>
        //public GetParamFromExcel AddFindText()
        //{
        //    var text = new GetParamFromExcel
        //    {
        //        TextToFind = ChoosEnergySystem_Combobox.Text
        //    };
        //    return text;
        //}

        ///// <summary>
        ///// ������������ �������� �������� � ��������� ������.
        ///// </summary>
        ///// <returns></returns>
        //public CalculPowerConsumption AddInitPower()
        //{
        //    var initP = new CalculPowerConsumption
        //    {
        //        InitPower = ControlText.CheckNumber(InputPower_textBox.Text)
        //    };

        //    return initP;
        //}

        ///// <summary>
        ///// ������ ������� ���������� �������� ��� ��.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Button_CalaulPower_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ChoosEnergySystem_Combobox.SelectedIndex < 0)
        //        {
        //            MessageBox.Show("�� �� ������� �� ��� �������!", "��������",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        var initTextFind = AddFindText();
        //        var initPower = AddInitPower();

        //        double[] P = initPower.CalculatePowerConsumption(initTextFind);

        //        listBox_PowerConsump.Items.Add($"P_max_0.92_����: {Math.Round(P[0], 0)}");
        //        listBox_PowerConsump.Items.Add($"P_max_����_����: {Math.Round(P[1], 0)}");

        //        listBox_PowerConsump.Items.Add($"P_min_0.92_����: {Math.Round(P[2], 0)}");
        //        listBox_PowerConsump.Items.Add($"P_min_0.92_����: {Math.Round(P[3], 0)}");

        //        listBox_PowerConsump.Items.Add($"P_max_0.98_����: {Math.Round(P[4], 0)}");
        //        listBox_PowerConsump.Items.Add($"P_max_����_����: {Math.Round(P[5], 0)}");

        //        listBox_PowerConsump.Items.Add($"P_min_����_����: {Math.Round(P[6], 0)}");

        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("�� �� ������� �������� ��������!", "��������",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        /// <summary>
        /// ���������� ������� ��� � JSON ����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_TableSPP_Click(object sender, EventArgs e)
        {
            if (_sppDataList.Count == 0)
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
                    _serializer.Serialize(file, _sppDataList);
                }
                MessageBox.Show("���� ������� ��������.",
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
                    _sppDataList = (BindingList<SolarPowerPlant>)_serializer.Deserialize(file);
                }

                dataGridView1.DataSource = _sppDataList;
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
            _sppDataList = new BindingList<SolarPowerPlant>();
            CreateTable(_sppDataList, dataGridView1);
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
        /// ���������� ��� � �������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewSPP_Click(object sender, EventArgs e)
        {
            AddForm addForm = new();

            addForm.SPPAdded += (sender, SPPEventArgs) =>
            {
                _sppDataList.Add(((SPPEventArgs)SPPEventArgs).SPP);
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
                _sppDataList.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }

        ///// <summary>
        ///// �������������� ��������� � ������� ���.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    this.dataGridView1.Rows[e.RowIndex].
        //        Cells["numberSPPDataGridViewTextBoxColumn"].
        //        Value = (e.RowIndex + 1).ToString();
        //}
    }
}