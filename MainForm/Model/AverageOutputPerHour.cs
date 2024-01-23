using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AverageOutputPerHour
    {
        /// <summary>
        /// Часы суток для которых определяется коэффициент. 
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Коэффициент средней выработки мощности СЭС в ЭС.
        /// </summary>
        public double AverageOutputPower { get; set; }
    }
}
