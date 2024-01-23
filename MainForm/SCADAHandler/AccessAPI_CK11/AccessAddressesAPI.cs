using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SCADAHandler.Object;
using Newtonsoft.Json;

namespace SCADAHandler.AccessAPI_CK11
{
    /// <summary>
    /// Класс для получения URL адресов publicAPI CK-11
    /// </summary>
    public class AccessAddressesAPI
    {
        /// <summary>
        /// Параметры для API запросов.
        /// Параметры: имя домена и версия подключения к ядру API
        /// </summary>
        private SettingAccessAPI _settingAccessAPI;

        /// <summary>
        /// Url адреса, запрошенные с публичного API CK-11.
        /// </summary>
        private Addresses _addresses;

        /// <summary>
        /// Параметры для API запросов.
        /// Параметры: имя домена и версия подключения к ядру API
        /// </summary>
        public SettingAccessAPI SettingAccesAPI
        {
            get { return _settingAccessAPI; }
            set { _settingAccessAPI = value; }
        }

        /// <summary>
        /// Url адреса, запрошенные с публичного API CK-11.
        /// </summary>
        public Addresses AddressesCK11
        {
            get => GetAddressesAPI().Result;
            set { _addresses = GetAddressesAPI().Result; }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="settingAccessAPI">Параметры для запроса url адрессов публичного API CK-11.
        /// Параметры: имя домена и версия подключения к ядру API.</param>
        public AccessAddressesAPI(SettingAccessAPI settingAccessAPI)
        {
            SettingAccesAPI = settingAccessAPI;
        }

        /// <summary>
        /// Функция возвращает объект класса Addresses, который содержит URL адреса публичного API CK-11
        /// </summary>
        /// <remarks>
        /// Подробно о применении этого запроса см. [Обнаружение адресов API](#/info/description/обнаружение-адресов-api).
        /// </remarks>
        /// <returns>Адреса публичного API успешно получены.</returns>
        public async Task<Addresses> GetAddressesAPI()
        {
            //Формирование базового url для запроса адрессов публичного API.
            string baseUrl = $"https://{SettingAccesAPI.NameDomen}/api/public/core/v{SettingAccesAPI.Version}";

            //Формирование url запроса для получения списка адрессов публичного API.
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(baseUrl != null ? baseUrl.TrimEnd('/') : "").Append("/addresses");

            //Формирование http сообщения для отправки запроса на получение адрессов публичного API.
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get
            };
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json;charset=UTF-8"));
            request.RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute);

            //Отправка GET запроса для получения публичных адресов API CK-11.
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            //Код ответа
            var statusCode = (int)response.StatusCode;
            var responseContent = await response.Content.ReadAsStringAsync();

            //Если ответ с адрессами пришел
            if (statusCode == 200)
            {
                //Проверка содержимого на Null
                if (responseContent == null)
                {
                    throw new CK11APIException("Неожиданный пустой ответ.", statusCode, responseContent, null);
                }
                //Дессириализация содержимого в класс Addresses
                Addresses addresses = JsonConvert.DeserializeObject<Addresses>(responseContent);
                return addresses;
            }
            else
            {
                CK11Exception exception = new CK11Exception();
                exception.ErrorStatusCode(statusCode, responseContent, CancellationToken.None);
                throw new NotImplementedException();
            }
        }
    }
}
