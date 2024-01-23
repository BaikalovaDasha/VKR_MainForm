using Microsoft.VisualBasic.FileIO;
using SCADAHandler.AccessAPI_CK11;
using SCADAHandler.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationModel
{
    /// <summary>
    /// Класс для расчёта коэффициента средней выработки.
    /// </summary>
    public class CalculAveragePowerCoefSPP
    {
        /// <summary>
        /// 
        /// </summary>
        public void CalculAverageCoefspp()
        {
            //AccessMesuremetValues meas = new();
            //ListMeasurementValuesExtend valueSummer = meas.
            //    GetMeasurementValuesArrayInRange().Result;

            var listPowerUTC9Winter = GetListUTC9(ValueWinter());
            var listPowerUTC9Summer = GetListUTC9(ValueSummer());

            // Максимальные и минимальные режимы работы за лето и зиму.
            var listMaxModeW = GetMaxMode(listPowerUTC9Winter);
            var listMaxModeS = GetMaxMode(listPowerUTC9Summer);


            var listMinModeW = GetMinMode(listPowerUTC9Winter);
            var listMinModeS = GetMinMode(listPowerUTC9Summer);

            // Максимальные и минимальные часы работы в максимальных и минимальных р.р.
            DateTime winterMaxH = GetMaxHour(listMaxModeW);
            DateTime summerMaxH = GetMaxHour(listMaxModeS);

            DateTime winterMinH = GetMinHour(listMinModeW);
            DateTime summerMinH = GetMinHour(listMinModeS);

            // Списки вырабатываемой мощности СЭС за лето и за зиму...
            // ... с меткой времени по Забайкалью.
            var listWinterSPP = GetListSPPUTC9(ValueWinter(), listPowerUTC9Winter);
            var listSummerSPP = GetListSPPUTC9(ValueSummer(), listPowerUTC9Summer);

            // Списки со средним коэффициентом выработки мощности каждой СЭС
            List<double> averageWinterMaxSPP = GetAveragePowerSPP(listWinterSPP, winterMaxH);
            List<double> averageSummerMaxSPP = GetAveragePowerSPP(listSummerSPP, summerMaxH);

            List<double> averageWinterMinSPP = GetAveragePowerSPP(listWinterSPP, winterMinH);
            List<double> averageSummerMinSPP = GetAveragePowerSPP(listSummerSPP, summerMinH);

            // коэффициент средней выработки СЭС.
            double averagePowerWinterMaxSPP = averageWinterMaxSPP.Average();
            double averagePowerSummerMaxSPP = averageSummerMaxSPP.Average();

            double averagePowerWinterMinSPP = averageWinterMinSPP.Average();
            double averagePowerSummerMinSPP = averageSummerMinSPP.Average();
        }

        /// <summary>
        /// Получение потрбеления энергорайона из запроса к БДРВ.
        /// </summary>
        /// <param name="list">запрошенный список по UID.</param>
        /// <returns>список с меткой времени по Забайкальскому часовому поясу.</returns>
        public List<ValuesMeasurement> GetListUTC9(ListMeasurementValuesExtend list)
        {
            var powerConsump = list.ListMeasurement.Last();

            var listPower = powerConsump.Value;

            var listPowerUTC9 = GetListUTC9(listPower);

            return listPowerUTC9;
        }

        /// <summary>
        /// Метод определяющий день (24 часа) по необходимому часу
        /// </summary>
        /// <param name="listComsumpES">список из значений потребления ЭС.</param>
        /// <param name="indexMode">индекс для определения даты.</param>
        /// <returns></returns>
        public static List<ValuesMeasurement> GetModeOperation
            (List<ValuesMeasurement> listComsumpES, int indexMode)
        {
            List<ValuesMeasurement> newlistComsumpES = new();
            var newDateMode = listComsumpES[indexMode].TimeStamp.Date;
            var ayeMode = listComsumpES.FirstOrDefault(o => o.TimeStamp.Date == newDateMode);
            int modeIndex = listComsumpES.IndexOf(ayeMode);

            for (int i = modeIndex; i < modeIndex + 24; i++)
            {
                newlistComsumpES.Add(listComsumpES[i]);
            }

            return newlistComsumpES;
        }

        /// <summary>
        /// Список за 24 часа с максимальным потреблением.
        /// </summary>
        /// <param name="listPowerUTC9"></param>
        /// <returns></returns>
        public List<ValuesMeasurement> GetMaxMode(List<ValuesMeasurement> listPowerUTC9)
        {
            // Максимальный режим работы
            var (maxMode, maxModeIndex) = listPowerUTC9.Select((x, i)
                => (x.Value, i)).Max();

            var listMaxMode = GetModeOperation(listPowerUTC9, maxModeIndex);

            return listMaxMode;
        }

        /// <summary>
        /// Список за 24 часа с минимальным потреблением.
        /// </summary>
        /// <param name="listPowerUTC9"></param>
        /// <returns></returns>
        public List<ValuesMeasurement> GetMinMode(List<ValuesMeasurement> listPowerUTC9)
        {
            // Минимальный режим работы.
            var (minMode, minModeIndex) = listPowerUTC9.Select((x, i)
                => (x.Value, i)).Min();

            var listMinMode = GetModeOperation(listPowerUTC9, minModeIndex);

            return listMinMode;
        }

        /// <summary>
        /// ПОлучение максимального часа потребления.
        /// </summary>
        /// <param name="listMaxMode"></param>
        /// <returns></returns>
        public DateTime GetMaxHour(List<ValuesMeasurement> listMaxMode)
        {
            // максимальный час потребления в максимальный р.р.
            var (maxHour, maxHourIndex) = listMaxMode.Select((x, i)
                => (x.Value, i)).Max();

            DateTime hourMax = listMaxMode[maxHourIndex].TimeStamp;

            return hourMax;

        }

        /// <summary>
        /// ПОлучение минимального часа потребления.
        /// </summary>
        /// <param name="listMaxMode"></param>
        /// <returns></returns>
        public DateTime GetMinHour(List<ValuesMeasurement> listMinMode)
        {
            // минимальный час потребления в минимальный р.р.
            var (minHour, minHourIndex) = listMinMode.Select((x, i)
                => (x.Value, i)).Min();

            DateTime hourMin = listMinMode[minHourIndex].TimeStamp;

            return hourMin;
        }

        /// <summary>
        /// Получение списка СЭС по часовому поясу Забайкалья.
        /// </summary>
        /// <param name="sppList">Исходный список в который вносят...
        /// ...изменяения без учёта последнего элемента в списке.</param>
        /// <param name="listPowerUTC9">список с часовым поясом по забайкалью.</param>
        /// <returns></returns>
        public List<ValuesMeasurementExtend> GetListSPPUTC9
            (ListMeasurementValuesExtend sppList,
            List<ValuesMeasurement> listPowerUTC9)
        {
            var listSPP = sppList.ListMeasurement.Take
                (sppList.ListMeasurement.Count - 1).ToList();

            listSPP = GetListSPPModeITC9(listSPP, listPowerUTC9);

            return listSPP;
        }

        /// <summary>
        /// Метод определяющий среднюю выработку СЭС в определённый час.
        /// </summary>
        /// <param name="listSPP">список выработки мощности СЭС.</param>
        /// <param name="hours">Необходимый час для определения средней выработки.</param>
        /// <returns>список со среднеми значениями выработки каждой СЭС по определённому часу.</returns>
        public static List<double> GetAveragePowerSPP(List<ValuesMeasurementExtend> listSPP, DateTime hours)
        {
            double sumPowerSPP = 0;
            List<double> averagePowerSPP = new();

            foreach (var item in listSPP)
            {
                int count = 0;

                foreach (var item1 in item.Value)
                {
                    if (item1.TimeStamp.Hour == hours.Hour)
                    {
                        sumPowerSPP += item1.Value;
                        count++;
                    }
                }

                averagePowerSPP.Add(sumPowerSPP / count);
            }
            return averagePowerSPP;
        }



        /// <summary>
        /// Метод изменяющий метку времени по UTC на Московский часовой пояс.
        /// </summary>
        /// <param name="listMode">Список с временем по UTC.</param>
        /// <returns>список с меткой времени по UTC+9.</returns>
        private static List<ValuesMeasurement> GetListUTC9(List<ValuesMeasurement> listMode)
        {
            foreach (var item in listMode)
            {
                item.TimeStamp = item.TimeStamp.AddHours(9);
            }
            return listMode;

        }

        /// <summary>
        /// Метод преобразующий метку времени в списке с СЭС в метку времени на Забайкальское время.
        /// </summary>
        /// <param name="listSPP">список СЭС с исходной меткой времени.</param>
        /// <param name="listUTC9">список с необходимой методкой времени.</param>
        /// <returns>список СЭС с меткой времени по Забайкальской ЭС.</returns>
        public static List<ValuesMeasurementExtend> GetListSPPModeITC9
            (List<ValuesMeasurementExtend> listSPP, List<ValuesMeasurement> listUTC9)
        {
            foreach (var item in listSPP)
            {
                foreach (var item1 in item.Value)
                {
                    item1.TimeStamp = listUTC9[item.Value.IndexOf(item1)].TimeStamp;
                }
            }

            return listSPP;
        }

        private ListMeasurementValuesExtend ValueSummer()
        {
            string[] summerArray =
            {   "лето[0].csv",
                "лето[1].csv",
                "лето[2].csv",
                "лето[3].csv",
                "лето[4].csv"
            };

            ListMeasurementValuesExtend summerList = CreateOIKList(summerArray);

            return summerList;
        }

        private ListMeasurementValuesExtend ValueWinter()
        {
            string[] winterArray =
            {   "зима[0].csv",
                "зима[1].csv",
                "зима[2].csv",
                "зима[3].csv",
                "зима[4].csv"
            };

            ListMeasurementValuesExtend winterList = CreateOIKList(winterArray);

            return winterList;
        }

        /// <summary>
        /// Метод для создания списка объектов из данных в формате csv, 
        /// сформированных при запросе данных ОИК (\get-table).
        /// (для работы без непосредственного доступа к OpenAPI)
        /// </summary>
        /// <param name="paths">Пути к csv файлам
        /// (файлы располагаются в корне bin\Debug)</param>
        /// <returns>Список объектов из данных ОИК</returns>
        public static ListMeasurementValuesExtend CreateOIKList(string[] paths)
        {
            ListMeasurementValuesExtend OIKList = new();
            foreach (string path in paths)
            {
                ValuesMeasurementExtend _item = new ValuesMeasurementExtend();
                List<ValuesMeasurement> subitemList = new List<ValuesMeasurement>();
                using (TextFieldParser parser = new TextFieldParser(path))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        Guid uuid = new();
                        //Processing row
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            if (fields[0] == "AcceessAPI.Object.ValuesMeasurement")
                            {
                                ValuesMeasurement _subitem = new ValuesMeasurement();
                                uuid = Guid.Parse(fields[1].ToString());
                                _subitem.UID = uuid;
                                _subitem.TimeStamp = DateTime.Parse(fields[2].ToString().AsSpan());
                                _subitem.TimeStamp2 = DateTime.Parse(fields[3].ToString().AsSpan());
                                _subitem.QCode = (long)Convert.ToDouble(fields[4]);
                                _subitem.Value = (double)Convert.ToDouble(fields[5]);
                                subitemList.Add(_subitem);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                _item.UID = subitemList.FirstOrDefault().UID;
                _item.Value = subitemList;
                OIKList.ListMeasurement.Add(_item);
            }

            return OIKList;
        }
        
    }
}
