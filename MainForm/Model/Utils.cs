using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс для проверки полей класса SolarPowerPlant.
    /// </summary>
    internal class Utils
    {

        /// <summary>
        /// Проверка параметра.
        /// </summary>
        /// <param name="number">Число для проверки.</param>
        /// <returns>проверенное число.</returns>
        /// <exception cref="ArgumentException">отбрасывает отрицательные...
        /// ...числа</exception>
        internal static double CheckingNumber(double number)
        {
            return number <= 0
                ? throw new ArgumentException("Число должно быть положительным.")
                : double.IsNaN(number) ? throw new ArgumentException("Нечисловое значение!") : number;
        }
    }
}
