using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm
{
    /// <summary>
    /// Класс проверок вводимого числа.
    /// </summary>
    public static class ControlText
    {

        /// <summary>
        /// Метод позволяющий вводить числа, запятые, точки и...
        /// ... использовать BackSpace.
        /// </summary>
        /// <param name="input"></param>
        public static void CheckInputDouble(KeyPressEventArgs input)
        {
            const int backSpace = 8;

            char number = input.KeyChar;
            if ((input.KeyChar < '0' || input.KeyChar > '9')
                && number != backSpace
                && number != ','
                && number != '.')
            {
                input.Handled = true;
            }
        }

        /// <summary>
        /// Метод позволяющий вводить числа, запятые, точки и...
        /// ... использовать BackSpace.
        /// </summary>
        /// <param name="input"></param>
        public static void CheckInputInt(KeyPressEventArgs input)
        {
            const int backSpace = 8;

            char number = input.KeyChar;
            if ((input.KeyChar < '0' || input.KeyChar > '9')
                && number != backSpace)
            {
                input.Handled = true;
            }
        }

        /// <summary>
        /// Преобразование числа в double.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double CheckNumber(string number)
        {
            if (number.Contains('.'))
            {
                number = number.Replace('.', ',');
            }
            return double.Parse(number);
        }
    }
}
