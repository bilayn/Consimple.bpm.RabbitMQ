using System.Net;
using TaskWithRabbitMQ.Framework.Infrastructure;

namespace TaskWithRabbitMQ.Infrastructure
{
    public static class AuthContext
    {
        public static string ServiceUri { get; } = $@"{Resources.BaseURL}/0/ServiceModel/EntityDataService.svc/";
        public static string AuthServiceUri { get; } = $@"{Resources.BaseURL}/ServiceModel/AuthService.svc/Login";
        public static CookieContainer AuthCookie = new CookieContainer();
    }
}
