using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADAHandler.Object
{
    [Serializable]
    public class MyProperties
    {
        public string[] UIDs { get; set; } = null;
        public string VersionAccess { get; set; }
        public string VersionMeasure { get; set; }
        public string TypeMeasure { get; set; }
        public string NameServer { get; set; } = null;

    }
}
