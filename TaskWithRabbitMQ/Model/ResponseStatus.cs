﻿namespace TaskWithRabbitMQ.Model
{
    // Вспомогательный класс для десериализации JSON-объекта из HTTP-ответа.
    public class ResponseStatus
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Exception { get; set; }
        public object PasswordChangeUrl { get; set; }
        public object RedirectUrl { get; set; }
    }
}
