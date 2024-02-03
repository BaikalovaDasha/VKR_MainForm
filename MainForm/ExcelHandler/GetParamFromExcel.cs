using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace ExcelHandler
{
    /// <summary>
    /// Получение параметров из Excel для расчёта потребления мощности.
    /// </summary>
    public class GetParamFromExcel
    {

        public string PathFile1;

        private readonly string _pathFile1;

        private readonly string _pathFile2;

        /// <summary>
        /// Чтение и запись искомой ЭС.
        /// </summary>
        public string TextToFind{ get; set; }

        public GetParamFromExcel(string value)
        {
            PathFile1 = value;
            _pathFile1 = PathFile1 + "\\power_consum_max_coefficient_2023_140623.xlsx";
            _pathFile2 = PathFile1 + "\\temp_coefficient_2023_140623.xlsx";
        }

        /// <summary>
        /// Метод открывающий файл Excel.
        /// </summary>
        /// <param name="_pathFile">Открываемый файл.</param>
        /// <returns>Лист в открытом файле excel.</returns>
        private Worksheet OpenFileExcel(string _pathFile)
        {
            // Excel
            Excel.Application xlApp = new();

            //рабочая книга
            Workbook xlWB;

            //лист Excel
            Worksheet xlSht;

            //название файла Excel
            xlWB = xlApp.Workbooks.Open(_pathFile);

            //название листа или 1-й лист в книге xlSht = xlWB.Worksheets[1];
            xlSht = xlWB.Worksheets[1];

            // добавление закрытия excel.xml
            // xlApp.Workbooks.Close();
            // xlApp.Quit();

            return xlSht;
        }

        /// <summary>
        /// Метод позволяющий искать номер строки ЭС в Excel.
        /// </summary>
        /// <param name="textToFind">Искомое слово.</param>
        /// <param name="xlSht">Лист в Excel.</param>
        /// <returns>Номер строки в Excel.</returns>
        private static int FindRowInExcel(string textToFind, Worksheet xlSht)
        {
            //диапазон ячеек
            Excel.Range Rng;

            textToFind = textToFind.Length > 6
                ? textToFind.Remove(textToFind.Length - 4)
                : textToFind.Remove(textToFind.Length - 2);

            // осуществляем поиск на листе
            Rng = xlSht.Cells.Find(textToFind, Type.Missing, XlFindLookIn.xlValues, XlLookAt.xlPart);

            int rowExcel = 0;

            if (Rng != null)
            {
                rowExcel = Convert.ToInt32(Regex.Replace(Rng.Address, @"[^\d]+", ""));
            }
            else
            {
                Console.WriteLine($"Текст {textToFind} на листе не найден!");
            }

            return rowExcel;
        }

        /// <summary>
        /// Получение массива коэффициенты зависимости изменения максимума...
        /// потребления мощности территориальных энергосистем при изменении...
        /// температуры наружного воздуха.
        /// </summary>
        /// <returns>массив коэффициентов.</returns>
        public List<double[]> FindExcelArray()
        {
            Worksheet xlSht = OpenFileExcel(_pathFile1);
            int rowExcel = FindRowInExcel(TextToFind, xlSht);

            List<double[]> listArrays = new();

            for (int j = 0; j < 6; j++)
            {
                if (xlSht.Cells[rowExcel, 3 + j].Value != null)
                {
                    double[] rowArray = new double[3];
                    rowArray[0] = (double)xlSht.Cells[rowExcel, 3 + j].Value;
                    rowArray[1] = (double)xlSht.Cells[rowExcel + 1, 3 + j].Value;
                    rowArray[2] = (double)xlSht.Cells[rowExcel + 2, 3 + j].Value;
                    listArrays.Add(rowArray);
                }
                else
                {
                    break;
                }
            }
            return listArrays;
        }

        /// <summary>
        /// Определение коэффициентов и расчётных температур наружного...
        /// воздуха ЭС, по наименованию ЭС.
        /// </summary>
        /// <returns>словарь коэффициентов и температур.</returns>
        public Dictionary<string, double> GetkoefToES()
        {
            Worksheet xlSht = OpenFileExcel(_pathFile2);
            int rowExcel = FindRowInExcel(TextToFind, xlSht);

            Dictionary<string, double> dictionaryKoef = new()
            {
                { "kZimaMinMax", xlSht.Cells[rowExcel, 3].Value },
                { "kLetoMinMax", xlSht.Cells[rowExcel, 4].Value },
                { "kLZMax", xlSht.Cells[rowExcel, 6].Value },
                { "tsrSIPR", xlSht.Cells[rowExcel, 38].Value },
                { "tLeto0.98", xlSht.Cells[rowExcel, 37].Value },
                { "tZima0.92", xlSht.Cells[rowExcel, 36].Value },
                { "tGOST", xlSht.Cells[rowExcel, 40].Value },
                { "tLetoNorm", xlSht.Cells[rowExcel, 39].Value }
            };

            return dictionaryKoef;
        }
    }
}
