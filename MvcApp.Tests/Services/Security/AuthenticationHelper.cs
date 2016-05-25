using MvcApp.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace MvcApp.Tests.Services.Security
{
    /// <summary>
    /// Just a dummy class to enable testing
    /// </summary>
    public class AuthenticationHelper : IAuthentication
    {
        public void Login(User user, bool persistCookie)
        {
        }

        public void Login(string username, bool persistCookie)
        {
        }

        public void Logout()
        {
        }

        public void RenewCurrentUser()
        {
        }
    }
}
