using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApp.Controllers;
using MvcApp.Tests.Repository.Data;
using Repository.Models;

namespace MvcApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _controller;

        public HomeControllerTest()
        {
            _controller = new HomeController(
                DataHelper.Session(
                        new User() { ID = 1, Username = "Akeel Mughal", Email = "akeel@email.com", Password = "test" }
                    ));
        }

        [TestMethod]
        public void HomeIndex()
        {
            ViewResult result = _controller.Index() as ViewResult;
            ControllerHelper.AssertController(result, _controller);
        }

        [TestMethod]
        public void HomeAbout()
        {
            ViewResult result = _controller.About() as ViewResult;
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
            ControllerHelper.AssertController(result, _controller);
        }

        [TestMethod]
        public void HomeContact()
        {
            ViewResult result = _controller.Contact() as ViewResult;
            ControllerHelper.AssertController(result, _controller);
        }
    }
}
