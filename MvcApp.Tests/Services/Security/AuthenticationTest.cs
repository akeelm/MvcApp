using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvcApp.Tests.Services.Security
{
    public class AuthenticationTest
    {
        [TestMethod]
        public void Login()
        {
            new MvcApp.Services.Security.Authentication().Login("test", false);
            Assert.IsTrue(false);
        }
    }
}
