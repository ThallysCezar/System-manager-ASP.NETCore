using CarRental.Models;

namespace CarRental.Helpers
{
    public interface ISession
    {
        void UserSessionCreation(UserModel user);
        void UserSessionRemove();
        UserModel SearchUserSession();
    }
}
