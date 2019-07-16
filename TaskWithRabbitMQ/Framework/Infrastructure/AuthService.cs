using System.IO;
using System.Net;
using Newtonsoft.Json;
using TaskWithRabbitMQ.Infrastructure;
using TaskWithRabbitMQ.Model;

namespace TaskWithRabbitMQ
{
    public static class AuthService
    {
        public static bool TryLogin(string userName, string userPassword)
        {
            // Создание экземпляра запроса к сервису аутентификации.
            var authRequest = WebRequest.Create(AuthContext.AuthServiceUri) as HttpWebRequest;
            // Определение метода запроса.
            authRequest.Method = "POST";
            // Определение типа контента запроса.
            authRequest.ContentType = "application/json";
            // Включение использования cookie в запросе.
            authRequest.CookieContainer = AuthContext.AuthCookie;

            // Помещение в тело запроса учетной информации пользователя.
            using (var requestStream = authRequest.GetRequestStream())
            {
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(@"{
                    ""UserName"":""" + userName + @""",
                    ""UserPassword"":""" + userPassword + @"""
                    }");
                }
            }

            // Вспомогательный объект, в который будут десериализованы данные HTTP-ответа.
            ResponseStatus status = null;
            // Получение ответа от сервера. Если аутентификация проходит успешно, в свойство AuthCookie будут
            // помещены cookie, которые могут быть использованы для последующих запросов.
            using (var response = (HttpWebResponse)authRequest.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    // Десериализация HTTP-ответа во вспомогательный объект.
                    string responseText = reader.ReadToEnd();
                    status = JsonConvert.DeserializeObject<ResponseStatus>(responseText);
                }

            }

            // Проверка статуса аутентификации.
            if (status != null)
            {
                // Успешная аутентификация.
                if (status.Code == 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
