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
        /// Для файлов.
        /// </summary>
        private readonly XmlSerializer _serializer = new(typeof(BindingList<SolarPowerPlant>));

        /// <summary>
        /// Запуск формы.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            var source = new BindingSource(_sppDataList, null);
            dataGridView1.DataSource = source;
        }

        /// <summary>
        /// Сохранение таблицы СЭС в JSON файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_TableSPP_Click(object sender, EventArgs e)
        {
            if (_sppDataList.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для сохранения.",
                    "Данные не сохранены", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.json)|*.json"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog.FileName.ToString();

                using (FileStream file = File.Create(path))
                {
                    _serializer.Serialize(file, _sppDataList);
                }
                MessageBox.Show("Файл успешно сохранён.",
                    "Сохранение завершено", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Открытие файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadTableSPP_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.json)|*.json"
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
                MessageBox.Show("Файл успешно загружен.", "Загрузка завершена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить файл.\n" +
                    "Файл повреждён или не соответствует формату.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Действия при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            _sppDataList = new BindingList<SolarPowerPlant>();
            CreateTable(_sppDataList, dataGridView1);
        }

        /// <summary>
        /// Создание таблицы DataGrid.
        /// </summary>
        /// <param name="sppList">Список СЭС.</param>
        /// <param name="dataGridView">таблица СЭС.</param>
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
        /// Добавление СЭС в таблицу.
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
        /// Удаление СЭС из таблицы.
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

        private void MenuItemStartCalculation_Click(object sender, EventArgs e)
        {
            Form form = new SettingsForm();
            form.ShowDialog();
        }
    }
}