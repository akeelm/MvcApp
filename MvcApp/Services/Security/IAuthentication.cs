namespace MvcApp.Services.Security
{
    /// <summary>
    /// Pluggable Authentication for testability
    /// </summary>
    public interface IAuthentication
    {
        void Login(string username, bool persistCookie);
        void Login(Repository.Models.User user, bool persistCookie);
        void Logout();
        void RenewCurrentUser();
    }
}