using ASTRALib;
using Model;
using System;
using System.ComponentModel;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CalculationModel
{
    public class CalculationRastrWin
    {
        /// <summary>
        /// Загрузка файла .rg2. "C:\Users\Дарья\Desktop\1. ВКР\ИТ\РМ"
        /// </summary>
        private static readonly string _pathFileWinter = "C:\\Users\\Дарья\\Desktop" +
            "\\1. ВКР\\ИТ\\РМ\\РМ_Зима.rg2";

        /// <summary>
        /// Загрузка файла .rg2. "C:\Users\Дарья\Desktop\1. ВКР\ИТ\РМ"
        /// </summary>
        private static readonly string _pathFileSummer = "C:\\Users\\Дарья\\Desktop" +
            "\\1. ВКР\\ИТ\\РМ\\РМ_Лето.rg2";

        /// <summary>
        /// Шаблон .rg2. "C:\Program Files\RastrWin3\RastrWin3\SHABLON\режим.rg2"
        /// </summary>
        private static readonly string _pathSablon = "C:\\Program Files\\" +
            "RastrWin3\\RastrWin3\\SHABLON\\режим.rg2";

        /// <summary>
        /// Создание указателя на экземпляр RastrWin и его запуск.
        /// </summary>
        private static IRastr _rastr = new Rastr();

        /// <summary>
        /// Загрузка файла с данными.
        /// </summary>
        /// <param name="pathFile">файл .rg2.</param>
        /// <param name="pathSablon">шаблон .rg2.</param>
        private static void LoadFile(string pathFile, string pathSablon)
        {
            _rastr.Load(RG_KOD.RG_REPL, pathFile, pathSablon);
        }

        /// <summary>
        /// Рассчитывает режим.
        /// </summary>
        public static void Regime()
        {
            _rastr.rgm("");
        }

        /// <summary>
        /// Сохранение файла .rg2.
        /// </summary>
        private static readonly Dictionary<int, string> _pathFileRG = new()
        {
            [1] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Зима_max.rg2",
            [2] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Лето_max.rg2",
            [3] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Зима_min.rg2",
            [4] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Лето_min.rg2",
        };

        /// <summary>
        /// Сохранение режима.
        /// </summary>
        /// <param name="pathFile">Загружаемый файл режима.</param>
        /// <param name="pathSablon">Режим шаблона.</param>
        public static void SaveRegime(string pathFile, string pathSablon)
        {
            _rastr.Save(pathFile, pathSablon);
        }

        /// <summary>
        /// Узнать индекс из любой таблицы по номеру (узела, агрегата, сечения).
        /// </summary>
        /// <param name="tableName">наименование таблицы.</param>
        /// <param name="columnName">наименование столбца.</param>
        /// <param name="number">номер агрегата/узла.</param>
        /// <returns>индекс строки в растре.</returns>
        public static int GetIndexByNumber(string tableName, string columnName, int number)
        {
            ITable Table = (ITable)_rastr.Tables.Item(tableName);
            ICol СolumnTable = (ICol)Table.Cols.Item(columnName);

            for (int index = 0; index < Table.Count; index++)
            {
                if ((int)СolumnTable.get_ZN(index) == number)
                {
                    return index;
                }
            }

            throw new Exception($"Агргеат с номером {number} не найден.");
        }

        /// <summary>
        /// Метод записывает значение в любую ячейку таблицы.
        /// </summary>
        /// <param name="tableName">наименование таблицы.</param>
        /// <param name="columnName">наименование столбца, где...
        /// происходит поиск параметра.</param>
        /// <param name="number">значения параметра.</param>
        /// <param name="chosenColumn">столбец в котором будут...
        /// меняться значения.</param>
        /// <param name="value">величина.</param>
        public static void SetValue(string tableName, string columnName, int number,
            string chosenColumn, double value)
        {
            ITable table = (ITable)_rastr.Tables.Item(tableName);
            ICol ColumnTable = (ICol)table.Cols.Item(chosenColumn);

            int index = GetIndexByNumber(tableName, columnName, number);
            ColumnTable.set_ZN(index, value);
        }

        /// <summary>
        /// Метод получение номеров агрегатов СЭС из списка.
        /// </summary>
        /// <param name="solarPowerPlant">Список СЭС.</param>
        /// <returns>Номера агрегатов.</returns>
        public static List<int> GetNumSPP(BindingList<SolarPowerPlant> solarPowerPlant)
        {
            List<int> listNumSPP = new();

            foreach (SolarPowerPlant spp in solarPowerPlant)
            {
                if (spp.StatusSPP == StatusSPP.вводимая)
                {
                    listNumSPP.Add(spp.NodeSPP);
                }

            }

            return listNumSPP;
        }

        /// <summary>
        /// Метод записывающий значение мощности вводимых СЭС.
        /// </summary>
        /// <param name="listSPP">список СЭС.</param>
        public static void SettingPowerGeneratorsSPPWinter(BindingList<SolarPowerPlant> solarPowerPlant)
        {
            LoadFile(_pathFileWinter, _pathSablon);

            foreach (var item in solarPowerPlant)
            {
                SetValue("Generator", "Num", item.NodeSPP, "P", item.EnteredOutputSPPMaxW);
                Regime();
                SaveRegime(_pathFileRG[1], _pathSablon);
            }

            foreach (var item in solarPowerPlant)
            {
                SetValue("Generator", "Num", item.NodeSPP, "P", item.EnteredOutputSPPMinW);
                Regime();
                SaveRegime(_pathFileRG[3], _pathSablon);
            }

        }

        /// <summary>
        /// Метод записывающий значение мощности вводимых СЭС.
        /// </summary>
        /// <param name="listSPP">список СЭС.</param>
        public static void SettingPowerGeneratorsSPPSummer(BindingList<SolarPowerPlant> solarPowerPlant)
        {
            LoadFile(_pathFileSummer, _pathSablon);

            foreach (var item in solarPowerPlant)
            {
                SetValue("Generator", "Num", item.NodeSPP, "P", item.EnteredOutputSPPMaxS);
                Regime();
                SaveRegime(_pathFileRG[2], _pathSablon);
            }

            foreach (var item in solarPowerPlant)
            {
                SetValue("Generator", "Num", item.NodeSPP, "P", item.EnteredOutputSPPMinS);
                Regime();
                SaveRegime(_pathFileRG[4], _pathSablon);
            }

        }

        /// <summary>
        /// Получить значение из любой ячейки любой таблицы
        /// </summary>
        /// <param name="tableName">название таблицы, в которой ведется поиск></param>
        /// <param name="parameterName">название параметра, по которому ищется индекс></param>
        /// <param name="number">номер узла (может быть так же номером сечения)></param>
        /// <param name="chosenParameter">любой параметр, значение из ячеек которого нужно получить
        /// (например, модуль текущего напряжения в узле)
        public static double GetValue(string tableName, string parameterName,
            int number, string chosenParameter)
        {
            ITable table = _rastr.Tables.Item(tableName);
            ICol columnItem = table.Cols.Item(chosenParameter);

            int index = GetIndexByNumber(tableName, parameterName, number);
            return columnItem.get_ZN(index);
        }

        /// <summary>
        /// Сохранение файла .rg2.
        /// </summary>
        private static readonly List<string> _pathFileOperModes = new()
        {
            "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Зима_max_0.92.rg2",
            "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Зима_max_ГОСТ.rg2",
            "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Зима_min_0.92.rg2",
            "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Зима_min_ГОСТ.rg2",
            "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Лето_max_0.98.rg2",
            "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Лето_max_лето_норм.rg2",
            "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\РМ_Лето_min_лето_норм.rg2",
        };

        private static string GetNameRegime(string text)
        {
            string[] x = text.Split('\\');
            string str = x[^1];
            string str1 = str.Replace(".rg2", string.Empty);
            return str1;
        }

        
        public static BindingList<OperatingModes> GetValueRastr(int na, BindingList<SolarPowerPlant> solarPowerPlant)
        {
            BindingList<OperatingModes> listOperModes = new();

            foreach (var item in _pathFileOperModes)
            {
                
                LoadFile(item, _pathSablon);
                ITable tableNode = (ITable)_rastr.Tables.Item("node");
                ICol columnNa = (ICol)tableNode.Cols.Item("na");
                ICol columnNy = (ICol)tableNode.Cols.Item("ny");
                ICol columnSta = (ICol)tableNode.Cols.Item("sta");
                ICol columnPg = (ICol)tableNode.Cols.Item("pg");

                ITable tableGenerator = (ITable)_rastr.Tables.Item("Generator");
                ICol columnNum = (ICol)tableGenerator.Cols.Item("Num");
                ICol columnNode = (ICol)tableGenerator.Cols.Item("Node");
                ICol columnP = (ICol)tableGenerator.Cols.Item("P");

                double pgBaseGen = 0;

                for (int index = 0; index < tableNode.Count; index++)
                {
                    if (columnNa.get_ZN(index) == na && columnSta.get_ZN(index) == false  && columnPg.get_ZN(index) > 0)
                    {
                        int node = columnNy.get_ZN(index);

                        for (int i = 0; i < tableGenerator.Count; i++)
                        {
                            if (columnNode.get_ZN(i) == node)
                            {
                                pgBaseGen += (double)columnP.get_ZN(i);
                            }
                        }
                    }
                }

                double pgSolarPlant = 0;

                foreach (var num in GetNumSPP(solarPowerPlant))
                {
                    for (int i = 0; i < tableGenerator.Count; i++)
                    {
                        if ((int)columnNum.get_ZN(i) == num)
                        {
                            pgSolarPlant += (double)columnP.get_ZN(i);
                        }
                    }
                }

                OperatingModes operMode = new()
                {
                    OperatingModesWithConsumption = GetNameRegime(item),
                    OutputBaseGeneration = pgBaseGen,
                    OutputSolarPlant = pgSolarPlant
                };

                operMode.Proportion = operMode.OutputSolarPlant / operMode.OutputBaseGeneration * 100;

                listOperModes.Add(operMode);
            }

            return listOperModes;
        }

        /// <summary>
        /// Сечения Забайкальской ЭС.
        /// </summary>
        private Dictionary<string, int> _sec { get; }
        = new Dictionary<string, int>
        {
            {"Иркутск-Бурятия", 60011},
            {"Юг - выдача", 60301},
            {"Восток", 60304},
            {"Запад", 60306},
            {"Маккавеево", 60307},
            {"Бурятия - Иркутск", 60290},
            {"Чита", 60311},
        };

        /// <summary>
        /// Определение запертых сечений.
        /// </summary>
        /// <returns>Список запертых сечений.</returns>
        private List<int> LockedSecs()
        {
            List<int> troubleSec = new();
            ITable Sec = (ITable)_rastr.Tables.Item("sechen");
            ICol PSec = (ICol)Sec.Cols.Item("psech");
            ICol PMax = (ICol)Sec.Cols.Item("pmax");

            foreach (var item in _sec)
            {
                if (PSec.get_ZN(GetIndexByNumber("sechen", "ns", item.Value)) > PMax.get_ZN(GetIndexByNumber("sechen", "ns", item.Value)))
                {
                    troubleSec.Add(item.Value);
                }
            }
            return troubleSec;
        }

        /// <summary>
        /// Загрузка/разгрузка базовой
        /// генерации для разгрузки КС.
        /// </summary>
        /// <returns>Разгружены ли КС
        /// базовой генерацией.</returns>
        private bool BaseGenChangeToUnlockSecs(int na, List<int> secs, BindingList<SolarPowerPlant> solarPowerPlant)
        {
            // Переменная меняет значение на true в случае,
            // когда все ограничения в КС сняты
            bool IsSecUnlocked = false;

            ITable Sec = (ITable)_rastr.Tables.Item("sechen");
            ICol PSec = (ICol)Sec.Cols.Item("psech");

            ITable tableNode = (ITable)_rastr.Tables.Item("node");
            ICol columnNa = (ICol)tableNode.Cols.Item("na");
            ICol columnNy = (ICol)tableNode.Cols.Item("ny");
            ICol columnSta = (ICol)tableNode.Cols.Item("sta");
            ICol columnPg = (ICol)tableNode.Cols.Item("pg");

            ITable tableGenerator = (ITable)_rastr.Tables.Item("Generator");
            ICol columnNum = (ICol)tableGenerator.Cols.Item("Num");
            ICol columnNode = (ICol)tableGenerator.Cols.Item("Node");
            ICol columnP = (ICol)tableGenerator.Cols.Item("P");
            ICol columnPMax = (ICol)tableGenerator.Cols.Item("Pmax");
            ICol columnPMin = (ICol)tableGenerator.Cols.Item("Pmin");

            // См. описание метода
            List<int> sppGens = GetNumSPP(solarPowerPlant);

            // Формируем список номеров (из таблицы Генераторы) включенных генераторов в районе
            List<int> basedGens = new List<int>();

            for (int index = 0; index < tableNode.Count; index++)
            {
                if (columnNa.get_ZN(index) == na && columnSta.get_ZN(index) == false && columnPg.get_ZN(index) > 0)
                {
                    int node = columnNy.get_ZN(index);

                    for (int i = 0; i < tableGenerator.Count; i++)
                    {
                        if (columnNode.get_ZN(i) == node && sppGens.IndexOf(columnNum.get_ZN(i)) == -1)
                        {
                            basedGens.Add(columnNum.get_ZN(i));
                        }
                    }
                }
            }

            // Разгружаем генераторы 
            while (!IsSecUnlocked)
            {
                // Создаем внутренний список,
                // чтобы исключать из него генераторы
                // по мерер достижения границ эксплуатационной характерстики
                foreach (var gen in basedGens)
                {
                    var pMax = columnPMax.get_ZN(GetIndexByNumber("Generator", "Num", gen));
                    var pMin = columnPMin.get_ZN(GetIndexByNumber("Generator", "Num", gen));

                    // Делаем проверку границ у генератора
                    // если границы нарушены, удаляем генератор
                    // и переходим к следующему (continue?)
                    double initSecLoad = PSec.get_ZN(GetIndexByNumber("sechen", "ns", secs.FirstOrDefault()));
                    columnPg.set_ZN(GetIndexByNumber("Generator", "Num", gen),
                        columnPg.get_ZN(GetIndexByNumber("Generator", "Num", gen)) + pMax * 0.02);

                    Regime();

                    if (Math.Abs(initSecLoad) > Math.Abs(PSec.get_ZN(GetIndexByNumber("sechen", "ns", secs.FirstOrDefault()))) &&
                       columnPg.get_ZN(GetIndexByNumber("Generator", "Num", gen)) < pMax)
                    {
                        continue;
                    }
                    else if (columnPg.get_ZN(GetIndexByNumber("Generator", "Num", gen)) > pMax)
                    {
                        columnPg.set_ZN(GetIndexByNumber("Generator", "Num", gen),
                        columnPg.get_ZN(GetIndexByNumber("Generator", "Num", gen)) - pMax * 0.02);
                        Regime();
                        basedGens.Remove(gen);
                    }
                    else if (columnPMin.get_ZN(GetIndexByNumber("Generator", "Num", gen)) > pMin)
                    {
                        columnPg.set_ZN(GetIndexByNumber("Generator", "Num", gen),
                        columnPg.get_ZN(GetIndexByNumber("Generator", "Num", gen)) - pMax * 0.02 * 2);
                        Regime();
                        if (columnPMin.get_ZN(GetIndexByNumber("Generator", "Num", gen)) < pMin)
                        {
                            columnPg.set_ZN(GetIndexByNumber("Generator", "Num", gen),
                            columnPg.get_ZN(GetIndexByNumber("Generator", "Num", gen)) + pMax * 0.02 * 2);
                            Regime();
                            basedGens.Remove(gen);
                        }
                    }

                }

                // Если кол-во запертых КС = 0,
                // то true.
                // Иначе если не осталось генераторов,
                // то false.
                // Иначе продолжаем работу в цикле while...
                if (LockedSecs().Count() == 0)
                {
                    IsSecUnlocked = true;
                }
                else if (basedGens.Count() == 0)
                {
                    return IsSecUnlocked;
                }
            }

            return IsSecUnlocked;
        }
       



    }
}
