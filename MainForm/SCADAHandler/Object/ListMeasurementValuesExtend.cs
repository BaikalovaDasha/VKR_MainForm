using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SCADAHandler.Object
{
    public class ListMeasurementValuesExtend
    {
        private List<ValuesMeasurementExtend> _listMeasurement;

        /// <summary>
        /// Список измерений
        /// </summary>
        [Newtonsoft.Json.JsonProperty("value")]
        public List<ValuesMeasurementExtend> ListMeasurement
        {
            get { return _listMeasurement; }
            set { _listMeasurement = value; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ListMeasurementValuesExtend()
        {
            _listMeasurement = new List<ValuesMeasurementExtend>();
        }

        public List<string> ToListString()
        {
            List<string> listValues = new();

            foreach (ValuesMeasurementExtend value in ListMeasurement)
            {
                string valueString = value.ToString();
                listValues.Add(valueString);
            }
            return listValues;
        }
    };

    [XmlRoot("RootElement", Namespace = "", IsNullable = false)]
    [Serializable]
    public class MeasureExtend
    {
        [XmlElement("Row")]
        public List<string> Strings { get; set; }
    }
}
