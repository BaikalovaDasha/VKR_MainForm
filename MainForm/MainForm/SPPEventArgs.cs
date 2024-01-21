using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm
{
    /// <summary>
    /// Класс события добавления СЭС.
    /// </summary>
    public class SPPEventArgs : EventArgs
    {
        /// <summary>
        /// Упражнение.
        /// </summary>
        public SolarPowerPlant SPP { get; private set; }

        /// <summary>
        /// Конструктор события добавления СЭС в таблицу СЭС.
        /// </summary>
        /// <param name="exercises"></param>
        public SPPEventArgs(SolarPowerPlant spp)
        {
            SPP = spp;
        }
    }
}
