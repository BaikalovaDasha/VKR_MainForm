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
        /// Выработка базовой генерации.
        /// </summary>
        private double _outputBaseGeneration;

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
        public double OutputBaseGeneration 
        { 
            get
            {
                return _outputBaseGeneration;
            }
            set
            {
                _outputBaseGeneration = CheckingNumber(value);
            }
        }

        /// <summary>
        /// Выработка СЭС.
        /// </summary>
        public double OutputSolarPlant { get; set; }

        /// <summary>
        /// Соотношение СЭС и базовой генерации.
        /// </summary>
        public double Proportion { get; set; }


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
    }
}
