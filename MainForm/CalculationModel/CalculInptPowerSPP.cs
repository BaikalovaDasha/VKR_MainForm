using SCADAHandler.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace CalculationModel
{
    /// <summary>
    /// Класс для расчёта вводимой мощности СЭС указанных на главной форме.
    /// </summary>
    public class CalculInptPowerSPP
    {
        private BindingList<SolarPowerPlant> _resultOutputPowerSPPCalcul = new();

        /// <summary>
        /// Метод расчёта мощности вводимых СЭС.
        /// </summary>
        /// <param name="listSPP">список СЭС.</param>
        /// <param name="count">номер режима.</param>
        /// <returns>вводимая мощность.</returns>
        public BindingList<SolarPowerPlant> GetInputPower
            (BindingList<SolarPowerPlant> solarPowerPlant,
            BindingList<AverageOutputPerHour> ResultOutputPerHour)
        {

            foreach (var itemspp in solarPowerPlant)
            {
                if (itemspp.StatusSPP == StatusSPP.willBePutIntoOperation)
                {
                    SolarPowerPlant newSpp = new()
                    {
                        NameSPP = itemspp.NameSPP,
                        InstalledCapacity = itemspp.InstalledCapacity
                    };
                    newSpp.EnteredOutputSPPMaxW = Math.Round(newSpp.InstalledCapacity * ResultOutputPerHour[0].KoefAverageOutputPower, 5);
                    newSpp.EnteredOutputSPPMaxS = Math.Round(newSpp.InstalledCapacity * ResultOutputPerHour[1].KoefAverageOutputPower, 5);
                    newSpp.EnteredOutputSPPMinW = Math.Round(newSpp.InstalledCapacity * ResultOutputPerHour[2].KoefAverageOutputPower, 5);
                    newSpp.EnteredOutputSPPMinS = Math.Round(newSpp.InstalledCapacity * ResultOutputPerHour[3].KoefAverageOutputPower, 5);
                    _resultOutputPowerSPPCalcul.Add(newSpp);
                }
            }
            return _resultOutputPowerSPPCalcul;
        }
    }
}
