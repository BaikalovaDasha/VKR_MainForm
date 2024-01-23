using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADAHandler.Object
{
    public class ValuesMeasurement
    {
        private Guid _uid = Guid.Empty;
        private DateTime _timeStamp = DateTime.MinValue;
        private DateTime _timeStamp2 = DateTime.MinValue;
        private long _qCode = 0;
        private double _value = 0.0;

        /// <summary>
        /// UID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid")]
        public Guid UID
        {
            get { return _uid; }
            set { _uid = value; }
        }

        /// <summary>
        /// Время
        /// </summary>
        [Newtonsoft.Json.JsonProperty("timeStamp")]
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        /// <summary>
        /// Время рождения
        /// </summary>
        [Newtonsoft.Json.JsonProperty("timeStamp2")]
        public DateTime TimeStamp2
        {
            get { return _timeStamp2; }
            set { _timeStamp2 = value; }
        }

        /// <summary>
        /// Код качества
        /// </summary>
        [Newtonsoft.Json.JsonProperty("qCode")]
        public long QCode
        {
            get { return _qCode; }
            set { _qCode = value; }
        }

        /// <summary>
        /// Значение
        /// </summary>
        [Newtonsoft.Json.JsonProperty("value")]
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        //public override string ToString()
        //{
        //    return UID + " | " + TimeStamp.ToString("yyyy.MM.dd HH:mm:ss") + " | " + Value;
        //}

        public string ToStringDateAndValue()
        {
            DateTime newTime = TimeStamp.Add(new TimeSpan(0, 7, 0, 0));
            return $"DATETIME_GMT=\"{newTime}\" POTR_AO=\"{Value}\"";
        }
    }
}
