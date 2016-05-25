using System.Web;
using System.Web.Security;

namespace MvcApp.Services.Security
{
    /// <summary>
    /// Class for handling standard FormsAuthentication stuff.
    /// </summary>
    public class Authentication : IAuthentication
    {
        public void Login(string username, bool persistCookie)
        {
            FormsAuthentication.SetAuthCookie(username, persistCookie);
        }

        public void Login(Repository.Models.User user, bool persistCookie)
        {
            FormsAuthentication.SetAuthCookie(user.Username, persistCookie);
            HttpContext.Current.Session["User"] = user;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public void RenewCurrentUser()
        {
            HttpCookie authCookie =
                HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = null;
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket != null && !authTicket.Expired)
                {
                    FormsAuthenticationTicket newAuthTicket = authTicket;

                    if (FormsAuthentication.SlidingExpiration)
                    {
                        newAuthTicket = FormsAuthentication.RenewTicketIfOld(authTicket);
                    }
                    string userData = newAuthTicket.UserData;
                    string[] roles = userData.Split(',');

                    HttpContext.Current.User =
                        new System.Security.Principal.GenericPrincipal(new FormsIdentity(newAuthTicket), roles);
                }
            }
        }
    }
}