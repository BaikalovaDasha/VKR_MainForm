using System.ComponentModel;

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
                _installedCapacity = value;
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
                _uniqueID = value;  
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
        public double KoefAveragepowerSPP { get; set; }

        /// <summary>
        /// Вводимая мощность СЭС в максимальный зимний период.
        /// </summary>
        public double EnteredOutputSPPMaxW { get; set; }

        /// <summary>
        /// Вводимая мощность СЭС в максимальный летний период.
        /// </summary>
        public double EnteredOutputSPPMaxS { get; set; }

        /// <summary>
        /// Вводимая мощность СЭС в минимальный зимний период.
        /// </summary>
        public double EnteredOutputSPPMinW { get; set; }

        /// <summary>
        /// Вводимая мощность СЭС в минимальный летний период.
        /// </summary>
        public double EnteredOutputSPPMinS { get; set; }
    }
}
