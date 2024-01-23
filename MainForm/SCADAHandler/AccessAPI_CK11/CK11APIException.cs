using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCADAHandler.Object;

namespace SCADAHandler.AccessAPI_CK11
{
    public class CK11APIException : Exception
    {
        public int StatusCode { get; private set; }

        public string? Response { get; private set; }

        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }

        public CK11APIException(string message, int statusCode, string? response, Exception? innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
        }
    }

    public partial class CK11APIException<TResult> : CK11APIException
    {
        public TResult? Result { get; private set; }

        public CK11APIException(string message, int statusCode, string response, TResult? result, Exception? innerException)
            : base(message, statusCode, response, innerException)
        {
            Result = result;
        }
    }

    public class CK11Exception
    {

        public async void ErrorStatusCode(int status_, string response_, CancellationToken cancellationToken)
        {
            try
            {
                if (status_ == 400)
                {
                    throw new CK11APIException("Использованы некорректные параметры запроса.", status_, response_, null);
                }
                else if (status_ == 401)
                {
                    throw new CK11APIException("Требуется выполнить аутентификацию.", status_, response_, null);
                }
                else if (status_ == 404)
                {
                    throw new CK11APIException("Объект не найден.", status_, response_, null);
                }
                else if (status_ == 422)
                {
                    throw new CK11APIException("Запрос синтаксически корректен, но его невозможно обработать по причине наличия семантических ошибок.", status_, response_, null);
                }
                else if (status_ == 500)
                {
                    throw new CK11APIException("Внутренняя ошибка сервера.", status_, response_, null);
                }
                else if (status_ == 502)
                {
                    throw new CK11APIException("Неверный ответ от вышестоящего сервера.", status_, response_, null);
                }
                else
                {
                    throw new CK11APIException("Неожиданный код состояния HTTP ответа (" + status_ + ").", status_, response_, null);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
            }
        }
    }
}
