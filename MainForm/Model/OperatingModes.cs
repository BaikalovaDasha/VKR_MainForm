using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Клас для отображения результатов расчётов оценки доли СЭС.
    /// </summary>
    public class OperatingModes
    {
        /// <summary>
        /// Gets or sets режимы работы формата .rg2.
        /// </summary>
        public string OperatingModesWithConsumption { get; set; }

        /// <summary>
        /// Резевирование СЭС.
        /// </summary>
        public string PowerReserves { get; set; }

        /// <summary>
        /// Выработка базовой генерации.
        /// </summary>
        public double OutputBaseGeneration { get; set; }

        /// <summary>
        /// Выработка СЭС.
        /// </summary>
        public double OutputSolarPlant { get; set; }

        /// <summary>
        /// Соотношение СЭС и базовой генерации.
        /// </summary>
        public double Proportion { get; set; }
    }
}
