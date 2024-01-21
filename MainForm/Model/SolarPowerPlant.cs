using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Model
{
    public class SolarPowerPlant
    {
        /// <summary>
        /// Номер СЭС.
        /// </summary>
        private int _numberSPP;

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
        /// Gets or sets номера СЭС.
        /// </summary>
        [DisplayName("№")]
        public int NumberSPP
        {
            get
            {
                return _numberSPP;
            }

            set
            {
                _numberSPP = value;
            }
        }

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
                _nodeSPP = (int)Utils.CheckingNumber(value);
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
                _installedCapacity = Utils.CheckingNumber(value); ;
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


    }
}
