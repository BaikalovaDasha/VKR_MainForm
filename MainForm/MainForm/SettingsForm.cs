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

namespace MainForm
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

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
        /// Подтверждение вносимых данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {

            AccessMesuremetValues meas = new();
            ListMeasurementValuesExtend valueSummer = meas.
                GetMeasurementValuesArrayInRange().Result;

            
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
