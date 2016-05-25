using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApp.Services.Security;

namespace MvcApp.Tests.Services.Security
{
    [TestClass]
    public class PasswordHashTest
    {
        [TestMethod]
        public void ValidatePassword()
        {
            var password = "Hell03309smA";
            var hash = PasswordHash.CreateHash(password);
            Assert.IsTrue(PasswordHash.ValidatePassword(password, hash));
        }
    }
}
