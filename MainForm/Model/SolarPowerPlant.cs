using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Model
{
    public class SolarPowerPlant
    {
        /// <summary>
        /// Нименование СЭС.
        /// </summary>
        private string _nameSPP;

        /// <summary>
        /// Статус СЭС.
        /// </summary>
        private StatusSPP _statusSPP;

        /// <summary>
        /// Узел СЭС в РМ.
        /// </summary>
        private int _nodeSPP;

        /// <summary>
        /// Установленная мощность.
        /// </summary>
        private double _installedCapacity;

        /// <summary>
        /// UID действующей СЭС.
        /// </summary>
        private string _uniqueID;

        /// <summary>
        /// Средняя выработка СЭС.
        /// </summary>
        private double _averageOutput;

        /// <summary>
        /// Вводимая мощность СЭС в максимальный зимний период.
        /// </summary>
        private double _enteredOutputSPPMaxW;

        /// <summary>
        /// Вводимая мощность СЭС в максимальный летний период.
        /// </summary>
        private double _enteredOutputSPPMaxS;

        /// <summary>
        /// Вводимая мощность СЭС в минимальный зимний период.
        /// </summary>
        private double _enteredOutputSPPMinW;

        /// <summary>
        /// Вводимая мощность СЭС в минимальный летний период.
        /// </summary>
        private double _enteredOutputSPPMinS;

        /// <summary>
        /// Коэффициент средней выработки СЭС.
        /// </summary>
        private double _koefAveragepowerSPP;

        /// <summary>
        /// Gets or sets наименование СЭС.
        /// </summary>
        [DisplayName("Наименование СЭС")]
        public string NameSPP
        {
            get
            {
                return _nameSPP;
            }

            set
            {
                _nameSPP = value;
            }
        }

        /// <summary>
        /// Gets or sets статуса СЭС.
        /// </summary>
        [DisplayName("Статус СЭС")]
        public StatusSPP StatusSPP 
        { 
            get
            {
                return _statusSPP;
            } 

            set
            {
                _statusSPP = value;
            }
        }

        /// <summary>
        /// Gets or sets узла в РМ.
        /// </summary>
        [DisplayName("Номер агрегата в РМ")]
        public int NodeSPP
        {
            get
            {
                return _nodeSPP;
            }

            set
            {
                _nodeSPP = value;
            }
        }

        /// <summary>
        /// Gets or sets энрегосистема.
        /// </summary>
        [DisplayName("Энергосистема")]
        public PowerSystem PowerSystem { get; set; }

        /// <summary>
        /// Gets or sets Установленная мощность.
        /// </summary>
        [DisplayName("Установленная мощность СЭС")]
        public double InstalledCapacity
        {
            get
            {
                return _installedCapacity;
            }

            set
            {
                _installedCapacity = CheckingNumber(value);
            }
        }

        /// <summary>
        /// Gets or sets номера СЭС.
        /// </summary>
        [DisplayName("UID СЭС в ОИК")]
        public string UIDspp
        {
            get
            {
                return _uniqueID;
            }

            set
            {
                if (StatusSPP == StatusSPP.вводимая)
                {
                    _uniqueID = CheckUID(value);
                }
                else
                {
                    _uniqueID = value;
                }
 
            }
        }

        /// <summary>
        /// Средняя выработка мощности СЭС.
        /// </summary>
        [DisplayName("Средняя выработка, МВт")]
        public double AverageOutput
        {
            get
            {
                return _averageOutput;
            }
            set
            {
                _averageOutput = value;
            }
        }

        /// <summary>
        /// Коэффициент средней выработки СЭС.
        /// </summary>
        [DisplayName("К_сэс, о.е.")]
        public double KoefAveragepowerSPP 
        { 
            get
            {
                return _koefAveragepowerSPP;
            }
            set
            {
                _koefAveragepowerSPP = ChecknegativeNumber(value);
            }
        }

        /// <summary>
        /// Вводимая мощность СЭС в максимальный зимний период.
        /// </summary>
        public double EnteredOutputSPPMaxW
        {
            get
            {
                return _enteredOutputSPPMaxW;
            }
            set
            {
                _enteredOutputSPPMaxW = CheckingNumber(value);
            }
        }

        /// <summary>
        /// Вводимая мощность СЭС в максимальный летний период.
        /// </summary>
        public double EnteredOutputSPPMaxS
        {
            get
            {
                return _enteredOutputSPPMaxS;
            }
            set
            {
                _enteredOutputSPPMaxS = CheckingNumber(value);
            }
        }

        /// <summary>
        /// Вводимая мощность СЭС в минимальный зимний период.
        /// </summary>
        public double EnteredOutputSPPMinW
        {
            get
            {
                return _enteredOutputSPPMinW;
            }
            set
            {
                _enteredOutputSPPMinW = CheckingNumber(value);
            }
        }

        /// <summary>
        /// Вводимая мощность СЭС в минимальный летний период.
        /// </summary>
        public double EnteredOutputSPPMinS 
        { 
            get
            {
                return _enteredOutputSPPMinS;
            }
            set
            {
                _enteredOutputSPPMinS = CheckingNumber(value);
            }
        }

        /// <summary>
        /// Максимальная выработка СЭС пересчитанная через коэффициент.
        /// </summary>
        public string MaxOutput { get; set; }

        /// <summary>
        /// Проверка параметра.
        /// </summary>
        /// <param name="number">Число для проверки.</param>
        /// <returns>проверенное число.</returns>
        /// <exception cref="ArgumentException">отбрасывает отрицательные...
        /// ...числа</exception>
        private double CheckingNumber(double number)
        {
            return number <= 0
                ? throw new ArgumentException("Число должно быть положительным.")
                : double.IsNaN(number) ? throw new ArgumentException("Нечисловое значение!") : number;
        }

        /// <summary>
        /// Проверка параметра.
        /// </summary>
        /// <param name="number">Число для проверки.</param>
        /// <returns>проверенное число.</returns>
        /// <exception cref="ArgumentException">отбрасывает отрицательные...
        /// ...числа</exception>
        private double ChecknegativeNumber(double number)
        {
            return number < 0
                ? throw new ArgumentException("Число должно быть положительным.")
                : double.IsNaN(number) ? throw new ArgumentException("Нечисловое значение!") : number;
        }

        /// <summary>
        /// Проверка на введённый UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected string CheckUID(string uid)
        {

            if (Regex.IsMatch(uid, @"\S{8}-\S{4}-\S{4}-\S{4}-\S{12}"))
            {
                return uid;
            }
            if (!Regex.IsMatch(uid, @"\S{8}-\S{4}-\S{4}-\S{4}-\S{12}"))
            {
                return uid;
            }
            else
            {
                throw new ArgumentException($"UID не удовлетворяет требованиям.");
            }

        }
    }
}
