using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SCADAHandler.Object
{
    public class ListMeasurementValues
    {
        private List<ValuesMeasurement> _listMeasurement;

        /// <summary>
        /// Список измерений
        /// </summary>
        [Newtonsoft.Json.JsonProperty("value")]
        public List<ValuesMeasurement> ListMeasurement
        {
            get { return _listMeasurement; }
            set { _listMeasurement = value; }
        }

        public List<string> ToListString()
        {
            List<string> listValues = new();

            foreach (ValuesMeasurement value in ListMeasurement)
            {
                // string valueString = value.ToString();
                string valueString = value.ToStringDateAndValue();
                listValues.Add(valueString);
            }
            return listValues;
        }
    };

    [XmlRoot("RootElement", Namespace = "", IsNullable = false)]
    [Serializable]
    public class Measure
    {
        [XmlElement("Row")]
        public List<string> Strings { get; set; }
    }
}
