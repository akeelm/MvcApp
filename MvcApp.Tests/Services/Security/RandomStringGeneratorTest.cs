using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvcApp.Tests.Services.Security
{
    [TestClass]
    public class RandomStringGeneratorTest
    {
        [TestMethod]
        public void GenerateRandomString()
        {
            var randomString = MvcApp.Services.Security.Random.GenerateString(10);
            Assert.AreEqual(randomString.Length, 10);
        }
    }
}
