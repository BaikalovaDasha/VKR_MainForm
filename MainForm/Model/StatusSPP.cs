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
        /// вводимая СЭС.
        /// </summary>
        willBePutIntoOperation,

        /// <summary>
        /// действующая СЭС.
        /// </summary>
        putIntoOperation
    }
}
