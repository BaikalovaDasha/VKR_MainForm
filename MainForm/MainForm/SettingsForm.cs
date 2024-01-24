using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SCADAHandler.Object;
using SCADAHandler.AccessAPI_CK11;
using Microsoft.VisualBasic.FileIO;
using static System.Windows.Forms.DataFormats;
using System.Runtime.Intrinsics.Arm;
using System.IO;
using Model;
using CalculationModel;

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

            //string[] powerSystem = { "Забайкальская", "Новосибирская", "Омская", "Башкортостана" };

            //ChoosEnergySystem_Combobox.Items.AddRange(new string[]
            //{
            //    powerSystem[0],
            //    powerSystem[1],
            //    powerSystem[2],
            //    powerSystem[3]
            //});
        }

        /// <summary>
        /// Ссылка на список СЭС из Form1.
        /// </summary>
        public BindingList<SolarPowerPlant> solarPowerPlant;

        /// <summary>
        /// 
        /// </summary>
        public BindingList<SolarPowerPlant>? ResultSPPCalcul = new();

        /// <summary>
        /// Подтверждение вносимых данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            ownerForm.SPPDataListWithKoefs = AddSPPResultList();

            // проверить работу метода
            //OverwiteFile();

            Close();
        }

        /// <summary>
        /// Метод добавления СЭС на результирующую форму.
        /// </summary>
        /// <returns></returns>
        public BindingList<SolarPowerPlant> AddSPPResultList()
        {
            CalculAveragePowerCoefSPP newlist = new();
            List<List<double>> listOutput = newlist.CalculAverageOutPutspp();
            List<SolarPowerPlant> operSPPList = new();

            foreach (var item in solarPowerPlant)
            {
                if (item.StatusSPP == StatusSPP.operating)
                {
                    operSPPList.Add(item);
                }

            }

            foreach (var itemOutput in listOutput)
            {

                foreach (var itemSPP in operSPPList)
                {
                    itemSPP.AverageOutput = Math.Round(itemOutput[operSPPList.IndexOf(itemSPP)], 5);
                    itemSPP.KoefAveragepowerSPP = Math.Round(itemSPP.AverageOutput / itemSPP.InstalledCapacity, 5);
                    ResultSPPCalcul.Add(itemSPP);

                }
            }

            return ResultSPPCalcul;
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
                if (item.StatusSPP == StatusSPP.operating)
                {
                    list.Add(item.UIDspp);
                }
            }

            string[] uids = list.ToArray();

            return uids;
        }

        /// <summary>
        /// Получение списка установленной мощности действующих СЭС.
        /// </summary>
        /// <param name="listspp"></param>
        /// <returns></returns>
        public List<double> GetCapacityNum(BindingList<SolarPowerPlant> listspp)
        {
            List<double> list = new();

            foreach (var item in listspp)
            {
                if (item.StatusSPP == StatusSPP.operating)
                {
                    list.Add(item.InstalledCapacity);
                }
            }
            return list;
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


        ///// <summary>
        ///// Контроль ввода значения исходной мощности.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ControlValue_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    ControlText.CheckInputDouble(e);
        //}

        ///// <summary>
        ///// Присваивание искомого слова в класс где происходит работа с Excel.
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
        ///// Присваивание исходной мощности в расчётный модуль.
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
        ///// Запуск расчёта потрбления мощности для ЭС.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Button_CalaulPower_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ChoosEnergySystem_Combobox.SelectedIndex < 0)
        //        {
        //            MessageBox.Show("Вы не выбрали ЭС для расчёта!", "Внимание",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        var initTextFind = AddFindText();
        //        var initPower = AddInitPower();

        //        double[] P = initPower.CalculatePowerConsumption(initTextFind);

        //        listBox_PowerConsump.Items.Add($"P_max_0.92_зима: {Math.Round(P[0], 0)}");
        //        listBox_PowerConsump.Items.Add($"P_max_ГОСТ_зима: {Math.Round(P[1], 0)}");

        //        listBox_PowerConsump.Items.Add($"P_min_0.92_зима: {Math.Round(P[2], 0)}");
        //        listBox_PowerConsump.Items.Add($"P_min_0.92_зима: {Math.Round(P[3], 0)}");

        //        listBox_PowerConsump.Items.Add($"P_max_0.98_лето: {Math.Round(P[4], 0)}");
        //        listBox_PowerConsump.Items.Add($"P_max_лето_норм: {Math.Round(P[5], 0)}");

        //        listBox_PowerConsump.Items.Add($"P_min_лето_норм: {Math.Round(P[6], 0)}");

        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Вы не указали исходную мощность!", "Внимание",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}


    }
}
