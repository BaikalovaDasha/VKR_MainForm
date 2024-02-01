using System.ComponentModel;
using SCADAHandler.Object;
using Model;
using CalculationModel;
using System;
using ExcelHandler;

namespace MainForm
{
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Событие добавления полученных расчётов.
        /// </summary>
        public EventHandler<EventArgs> AddedCalcul;

        Form1 ownerForm = null;

        public SettingsForm(Form1 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;

            string[] powerSystem = { "Забайкальская", "Новосибирская", "Омская", "Башкортостана" };

            ChoosEnergySystemCombobox.Items.AddRange(new string[]
            {
                powerSystem[0],
                powerSystem[1],
                powerSystem[2],
                powerSystem[3]
            });
        }

        /// <summary>
        /// Ссылка на список СЭС из Form1.
        /// </summary>
        public BindingList<SolarPowerPlant> solarPowerPlant;

        /// <summary>
        /// Список действующих СЭС с коэффициентами средней выработки по каждой СЭС.
        /// </summary>
        public BindingList<SolarPowerPlant> ResultSPPCalcul = new();

        /// <summary>
        /// Список СЭС для Form1 с рассчитанным коэффициентом средней выработки.
        /// </summary>
        public BindingList<AverageOutputPerHour> ResultOutputPerHour = new();

        /// <summary>
        /// Список СЭС для Form1 с рассчитанным коэффициентом средней выработки.
        /// </summary>
        public BindingList<SolarPowerPlant> InputPowerSPPWithNum = new();

        public double[] powerConsumption;

        /// <summary>
        /// Подтверждение вносимых данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrEmpty(textBoxUIDPowerConsump.Text))
                //{
                //    MessageBox.Show("Вы не ввели UID потребления ЭС", "Внимание",
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                //if (ChoosEnergySystemCombobox.SelectedIndex < 0)
                //{
                //    MessageBox.Show("Вы не выбрали ЭС для расчёта!", "Внимание",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                //if (string.IsNullOrEmpty(textBoxInitPower.Text))
                //{
                //    MessageBox.Show("Вы не указали исходную мощность!", "Внимание",
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                OverwiteFile();

                ownerForm.SPPDataListWithKoefs = AddSPPResultList();
                ownerForm.KoefDataList = AddKoefOutputResult();

                CalculInptPowerSPP outputPowerSPPCalcul = new();
                InputPowerSPPWithNum = outputPowerSPPCalcul.
                    GetInputPower(solarPowerPlant, ResultOutputPerHour);

                ownerForm.ResultOutputPowerSPPCalcul = InputPowerSPPWithNum;

                //powerConsumption = AddInitPower().CalculatePowerConsumption(AddFindText());

                //CalculationRastrWin.SettingPowerGeneratorsSPPWinter(InputPowerSPPWithNum);
                //CalculationRastrWin.SettingPowerGeneratorsSPPSummer(InputPowerSPPWithNum);
                //CalculationRastrWin.GetValueRastr(603, solarPowerPlant);
                CalculationRastrWin.BaseGenChangeToUnlockSecs(603, CalculationRastrWin.LockedSecs(), solarPowerPlant);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }

        /// <summary>
        /// Создание списка со средней выработкой и коэффициентами СЭС для...
        /// ...определения коэффициента средней выработки СЭС по ЭС.
        /// </summary>
        /// <returns></returns>
        public BindingList<SolarPowerPlant> AddSPPResultList()
        {
            CalculAveragePowerCoefSPP newlist = new();
            List<List<double>> listOutput = newlist.CalculAverageOutPutspp();

            List<SolarPowerPlant> operSPPList = OperSPP();

            foreach (var itemOutput in listOutput)
            {
                foreach (var itemSPP in operSPPList)
                {
                    SolarPowerPlant sppItem = new()
                    {
                        NameSPP = itemSPP.NameSPP,
                        NodeSPP = itemSPP.NodeSPP,
                        AverageOutput = Math.Round(itemOutput[operSPPList.IndexOf(itemSPP)], 5),
                        InstalledCapacity = itemSPP.InstalledCapacity
                    };
                    sppItem.KoefAveragepowerSPP = Math.Round(sppItem.AverageOutput / sppItem.InstalledCapacity, 5);
                    ResultSPPCalcul.Add(sppItem);
                }
            }

            return ResultSPPCalcul;
        }

        /// <summary>
        /// Метод добавления времени и среднего коэффициента выработки СЭС на главную форму.
        /// </summary>
        /// <returns></returns>
        public BindingList<AverageOutputPerHour> AddKoefOutputResult()
        {
            CalculAveragePowerCoefSPP newlist = new();
            List<DateTime> listdateTime = newlist.GetTime();
            List<SolarPowerPlant> operSPPList = OperSPP();

            List<double> doubles = new();

            foreach (var item in ResultSPPCalcul)
            {
                doubles.Add(item.KoefAveragepowerSPP);
            }

            List<double> koefAverageWinterMaxSPP = doubles.Skip(0).Take(operSPPList.Count).ToList();
            List<double> koefAverageSummerMaxSPP = doubles.Skip(operSPPList.Count).Take(operSPPList.Count).ToList();

            List<double> koefAverageWinterMinSPP = doubles.Skip(operSPPList.Count * 2).Take(operSPPList.Count).ToList();
            List<double> koefAverageSummerMinSPP = doubles.Skip(operSPPList.Count * 3).Take(operSPPList.Count).ToList();

            List<double> koefList = new()
            {
                koefAverageWinterMaxSPP.Average(),
                koefAverageSummerMaxSPP.Average(),
                koefAverageWinterMinSPP.Average(),
                koefAverageSummerMinSPP.Average(),
            };

            foreach (var item in listdateTime)
            {
                AverageOutputPerHour dateTimeItem = new();
                dateTimeItem.Time = item;
                ResultOutputPerHour.Add(dateTimeItem);
            }

            foreach (var item in ResultOutputPerHour)
            {
                item.KoefAverageOutputPower = Math.Round(koefList[ResultOutputPerHour.IndexOf(item)], 5);
            }

            return ResultOutputPerHour;
        }

        /// <summary>
        /// Получение списка действующих СЭС.
        /// </summary>
        /// <returns></returns>
        private List<SolarPowerPlant> OperSPP()
        {
            List<SolarPowerPlant> operSPPList = new();

            foreach (var item in solarPowerPlant)
            {
                if (item.StatusSPP == StatusSPP.действующая)
                {
                    operSPPList.Add(item);
                }
            }
            return operSPPList;
        }

        /// <summary>
        /// Метод перезаписывающий файл в котором хранятся...
        /// ...настройки для получения токена.
        /// </summary>
        private void OverwiteFile()
        {
            string[] uidsSPP = GetUidsSPP(solarPowerPlant);
            string[] uids = Append(uidsSPP, textBoxUIDPowerConsump.Text);

            MyProperties? properties = new()
            {
                UIDs = uids,
                VersionAccess = textBoxVersionAccess.Text,
                VersionMeasure = textBoxMeasurementValues.Text,
                TypeMeasure = textBoxTypeMeasure.Text,
                NameServer = textBoxNameServer.Text
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize<MyProperties>(properties);

            StreamWriter SW = new(new FileStream("MySettings1.json", FileMode.OpenOrCreate, FileAccess.Write));
            SW.Write(jsonString);
            SW.Close();
        }

        /// <summary>
        /// Создание массива данных с UID потреблением.
        /// </summary>
        /// <param name="uidsSPP"></param>
        /// <param name="uidsConsump"></param>
        /// <returns></returns>
        private static string[] Append(string[] uidsSPP, string uidsConsump)
        {
            if (uidsSPP == null)
            {
                return new string[] { uidsConsump };
            }
            string[] result = new string[uidsSPP.Length + 1];
            uidsSPP.CopyTo(result, 0);
            result[uidsSPP.Length] = uidsConsump;
            return result;
        }

        /// <summary>
        /// Формирование массива UID из Form1 таблицы СЭС.
        /// </summary>
        /// <param name="listspp"></param>
        /// <returns></returns>
        private string[] GetUidsSPP(BindingList<SolarPowerPlant> listspp)
        {
            List<string> list = new();

            foreach (var item in listspp)
            {
                if (item.StatusSPP == StatusSPP.действующая)
                {
                    list.Add(item.UIDspp);
                }
            }

            string[] uids = list.ToArray();

            return uids;
        }

        /// <summary>
        /// Автозаполнение в полях настроек для подключения к БДРВ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string jsonString = File.ReadAllText("MySettings1.json");
            MyProperties? properties = System.Text.Json.JsonSerializer.Deserialize<MyProperties>(jsonString);
            textBoxVersionAccess.Text = properties.VersionAccess;
            textBoxMeasurementValues.Text = properties.VersionMeasure;
            textBoxNameServer.Text = properties.NameServer;
            textBoxTypeMeasure.Text = properties.TypeMeasure;
        }

        /// <summary>
        /// Контроль ввода значения исходной мощности.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlText.CheckInputDouble(e);
        }

        /// <summary>
        /// Присваивание искомого слова в класс где происходит работа с Excel.
        /// </summary>
        /// <returns></returns>
        public GetParamFromExcel AddFindText()
        {
            var text = new GetParamFromExcel
            {
                TextToFind = ChoosEnergySystemCombobox.Text
            };
            return text;
        }

        /// <summary>
        /// Присваивание исходной мощности в расчётный модуль.
        /// </summary>
        /// <returns></returns>
        public CalculPowerConsumption AddInitPower()
        {
            var initP = new CalculPowerConsumption
            {
                InitPower = ControlText.CheckNumber(textBoxInitPower.Text)
            };

            return initP;
        }
    }
}
