using System.Net.Http.Headers;
using System.Text;
using SCADAHandler.Object;
using Newtonsoft.Json;

namespace SCADAHandler.AccessAPI_CK11
{
    public class AccessMesuremetValues
    {
        /// <summary>
        /// UID измерения.
        /// </summary>
        private string[] _uids;

        /// <summary>
        /// Тип измерения (например numeric)
        /// </summary>
        private string _typeMeasure;

        /// <summary>
        /// Время начала сбора измерений.
        /// </summary>
        private DateTime _dateStamp;

        /// <summary>
        /// Время конца сбора измерений.
        /// </summary>
        private DateTime _dateEnd;

        /// <summary>
        /// Экземпляр класса ListMeasurementValues, содержащий
        /// информаицию о собранных измерениях за период.
        /// </summary>
        private ListMeasurementValues _listMeasurementValues = null;

        /// <summary>
        /// Экземпляр класса ListMeasurementValuesExtend, содержащий
        /// информаицию о собранных измерениях за период.
        /// </summary>
        private ListMeasurementValuesExtend _listMeasurementValuesExtend = null;

        /// <summary>
        /// Параметры для запросов адресов и токена с API.
        /// Включает в себя имя домена и версию подключения (например "2.1")
        /// </summary>
        private SettingAccessAPI _settingAPI;

        /// <summary>
        /// Параметры для запросов значений измерений с API.
        /// Включает в себя имя домена и версию подключения (например "2.1")
        /// </summary>
        private SettingMeasurementAPI _settingMeasurementAPI;

        /// <summary>
        /// UID измерения.
        /// </summary>
        public string[] UIDs
        {
            get { return _uids; }
            set { _uids = value; }
        }

        /// <summary>
        /// Тип измерения (например numeric)
        /// </summary>
        public string TypeMeasure
        {
            get { return _typeMeasure; }
            set { _typeMeasure = value; }
        }

        /// <summary>
        /// Время конца сбора измерений.
        /// </summary>
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }

        /// <summary>
        /// Время начала сбора измерений.
        /// По умолчанию - за 2 дня до текущего времени
        /// </summary>
        public DateTime DateStamp
        {
            get { return _dateStamp; }
            set { _dateStamp = value; }
        }

        /// <summary>
        /// Параметры для запросов адресов и токена с API. 
        /// Включает в себя имя домена и версию подключения (например "2.1")
        /// </summary>
        public SettingAccessAPI SettingAPI
        {
            get { return _settingAPI; }
            set { _settingAPI = value; }
        }

        /// <summary>
        /// Параметры для запросов значений измерений с API. 
        /// Включает в себя имя домена и версию подключения (например "2.1")
        /// </summary>
        public SettingMeasurementAPI SettingMeasureAPI
        {
            get { return _settingMeasurementAPI; }
            set { _settingMeasurementAPI = value; }
        }

        /// <summary>
        /// Токен для доступа к измерениям.
        /// </summary>
        public Token Token
        {
            get { return new AccessRequestToken(SettingAPI).Token; }
        }

        /// <summary>
        /// Экземпляр класса ListMeasurementValues, содержащий
        /// информаицию о собранных измерениях за период.
        /// </summary>
        public ListMeasurementValuesExtend ListMeasurementValuesExtend
        {
            get { return GetMeasurementValuesArrayInRange().Result; }
            set { _listMeasurementValuesExtend = GetMeasurementValuesArrayInRange().Result; }
        }

        /// <summary>
        /// Конуструктор класса
        /// </summary>
        /// <param name="uid">UID измерения.</param>
        /// <param name="dateStamp">Время начала сбора измерений.</param>
        /// <param name="dateEnd">Время конца сбора измерений.</param>
        /// <param name="settingAccessAPI">Параметры для запроса измерений по API. 
        /// Включает в себя имя домена и версию подключения (например "2.1").</param>
        /// <param name="typeMeasure">Тип измерения (например numeric).</param>
        public AccessMesuremetValues(string[] uid, DateTime dateStamp, DateTime dateEnd,
                                     SettingAccessAPI settingAccessAPI, SettingMeasurementAPI settingMeasurement, string typeMeasure)
        {
            UIDs = uid;
            DateStamp = dateStamp;
            DateEnd = dateEnd;
            SettingAPI = settingAccessAPI;
            SettingMeasureAPI = settingMeasurement;
            TypeMeasure = typeMeasure;
        }

        public AccessMesuremetValues()
        {
        }

        /// <summary>
        /// Конуструктор класса
        /// </summary>
        /// <param name="uids">UID измерений.</param>
        public AccessMesuremetValues(string[] uids, SettingAccessAPI settingAccessAPI, SettingMeasurementAPI settingMeasurement, string typeMeasure)
        {
            UIDs = uids;
            SettingAPI = settingAccessAPI;
            SettingMeasureAPI = settingMeasurement;
            TypeMeasure = typeMeasure;
        }

        /// <summary>
        /// формирование строкового формата даты для получени значений.
        /// </summary>
        /// <param name="fromTimeStampDate"></param>
        /// <returns></returns>
        public static string GetDateTimeString(DateTime fromTimeStampDate)
        {
            string fromTimeStampStr = fromTimeStampDate.ToString("yyyy-MM-dd HH:mm:ss");

            fromTimeStampStr = fromTimeStampStr.Replace(" ", "T");

            fromTimeStampStr += 'Z';

            return fromTimeStampStr;
        }

        /// <summary>
        /// Получение списка значений измерений
        /// </summary>
        /// <returns>Перечень измерений</returns>
        public async Task<ListMeasurementValuesExtend> GetMeasurementValuesArrayInRange()
        {
            // Токен получили, запрашиваем значения
            //Формирование url адресса для получения значений измерения.
            string url = $"https://{SettingMeasureAPI.NameDomen}/api/public/measurement-values/" +
                         $"v{SettingMeasureAPI.Version}/{TypeMeasure}/data/" +
                         $"get-table";
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(url);

            //Создание клиента для запроса списка значений измерения.
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token.AccessToken);

            //Создание GET сообщения для запроса списка значений измерения.
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get
            };
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json;charset=UTF-8"));
            request.RequestUri = new Uri(url.ToString(), UriKind.RelativeOrAbsolute);

            string content = "{\"uids\": " + ArrayToString(UIDs) + "\"fromTimeStamp\": \"" + GetDateTimeString(DateStamp) + "\", \"toTimeStamp\": \"" + GetDateTimeString(DateEnd) + "\", \"stepUnits\": \"seconds\", \"stepValue\": 3600}";

            //Отправка запроса на получение списка значений измерения.
            HttpResponseMessage response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            var statusCode = (int)response.StatusCode;
            //Содержимое ответа
            string responseContent = await response.Content.ReadAsStringAsync();


            if (statusCode == 200)
            {
                if (responseContent == null)
                {
                    throw new CK11APIException("Неожиданный пустой ответ.", statusCode, responseContent, null);
                }
                else
                {
                    //Дессириализация содержимого в класс ListMeasurementValues
                    ListMeasurementValuesExtend measurements = JsonConvert.DeserializeObject<ListMeasurementValuesExtend>(responseContent);
                    return measurements;
                }
            }
            else
            {
                CK11Exception exception = new CK11Exception();
                exception.ErrorStatusCode(statusCode, responseContent, CancellationToken.None);
                return null!;
            }
        }

        /// <summary>
        /// Метод для создания строки...
        /// ...формата StringContent из массива.
        /// </summary>
        /// <param name="strings">Массив.</param>
        /// <returns>Строка.</returns>
        public static string ArrayToString(string[] strings)
        {
            StringBuilder sb = new StringBuilder("[");
            foreach (string s in strings)
            {
                sb.Append("\"" + s + "\", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("],");
            return sb.ToString();
        }
    }
}
