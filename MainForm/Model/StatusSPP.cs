using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{ 
    /// <summary>
    /// Перечисление существующих статусов СЭС.
    /// </summary>
    public enum StatusSPP
    {
        /// <summary>
        /// вводимая СЭС. willBePutIntoOperation
        /// </summary>
        [Description("вводимая")]
        вводимая,

        /// <summary>
        /// действующая СЭС.putIntoOperation
        /// </summary>
        [Description("действующая")]
        действующая
    }
}
