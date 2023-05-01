using CarRental.Models;
using Newtonsoft.Json;

namespace CarRental.Helpers
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UserModel SearchUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("loggedInUserSession");

            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }

        public void UserSessionCreation(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("loggedInUserSession", value);
        }

        public void UserSessionRemove()
        {
            _httpContext.HttpContext.Session.Remove("loggedInUserSession");
        }
    }
}
