using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCADAHandler.Object;
using Newtonsoft.Json;

namespace SCADAHandler.AccessAPI_CK11
{
    public class AccessRequestToken
    {

        /// <summary>
        /// Экземпляр класса AccessAdressesAPI, 
        /// содержащий список публичных адрессов API CK-11
        /// </summary>
        private AccessAddressesAPI _addresesAPI;

        /// <summary>
        /// Токен (ключ доступа) запрошенный с API CK-11.
        /// </summary>
        private Token _token;

        /// <summary>
        /// Параметры для запросов с API.
        /// доменное имя и версия подключения к ядру API
        /// </summary>
        private SettingAccessAPI _settingAPI;

        /// <summary>
        /// Токен (ключ доступа) запрошенный с API CK-11.
        /// </summary>
        public Token Token
        {
            get { return GetToken().Result; }
            set { _token = GetToken().Result; }
        }

        /// <summary>
        /// Параметры для запросов с API:
        /// доменное имя и версия подключения к ядру API
        /// </summary>
        public SettingAccessAPI SettingAPI
        {
            get { return _settingAPI; }
            set { _settingAPI = value; }
        }

        /// <summary>
        /// Экземпляр класса AccessAdressesAPI, 
        /// содержащий список публичных адрессов API CK-11
        /// </summary>
        public AccessAddressesAPI AddressesAPI
        {
            get { return new AccessAddressesAPI(SettingAPI); }
        }

        /// <summary>
        /// Конструктор класса AccessRequestToken.
        /// </summary>
        /// <param name="settingAccsesAPI">Параметры подключения к API СК-11: 
        /// Доменное имя и версия подключения к ядру API</param>
        public AccessRequestToken(SettingAccessAPI settingAccsesAPI)
        {
            _settingAPI = settingAccsesAPI;
        }

        /// <summary>
        /// Получение токена по встроенной аутинтификации
        /// Аутентификация проходит от локального пользователя, который находится в домене.
        /// </summary>
        /// <returns>Токен</returns>
        public async Task<Token> GetToken()
        {
            Token token = null;
            try
            {


                //Url для получения токена по внутренней авторизации
                //Права получаются от пользователя находящего в домене.
                string authUrl = AddressesAPI.AddressesCK11.auth.tokenEndpointEmbedded;

                //Даем понять, что авторизуемся от текущего пользователя, находящегося в домене
                var httpHandler = new HttpClientHandler()
                {
                    UseDefaultCredentials = true,
                };

                //Создание http клиента
                var authClient = new HttpClient(httpHandler);

                //Отправка запроса на получение токена .ConfigureAwait(false);

                HttpResponseMessage authResponse = await authClient.PostAsync(authUrl, new StringContent("{}", Encoding.UTF8, "application/json")).ConfigureAwait(false);


                //Код ответа
                var statusCode = (int)authResponse.StatusCode;
                //Содержание ответа
                var responseContent = await authResponse.Content.ReadAsStringAsync();

                //Проверка статуса ответа
                if (statusCode == 200)
                {
                    //Дессериализация содержимого в класс Token
                    token = JsonConvert.DeserializeObject<Token>(responseContent);

                    if (responseContent == null)
                    {
                        throw new CK11APIException("Неожиданный пустой ответ.", statusCode, responseContent, null);
                    }
                }
                else
                {
                    CK11Exception exception = new CK11Exception();
                    exception.ErrorStatusCode(statusCode, responseContent, CancellationToken.None);
                    throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
            }
            return token;
        }
    }
}
