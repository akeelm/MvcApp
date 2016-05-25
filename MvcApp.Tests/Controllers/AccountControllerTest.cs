using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApp.Controllers;
using MvcApp.Tests.Repository.Data;
using MvcApp.Tests.Services.Security;
using MvcApp.Tests.StructureMapRegistry;
using MvcApp.ViewModels.Account;
using Repository.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace MvcApp.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        private AccountController _controller;

        public AccountControllerTest()
        {
            var dataSession = DataHelper.Session(
                        new User() { ID = 1, Username = "akeelm", Email = "akeel@email.com", Password = MvcApp.Services.Security.PasswordHash.CreateHash("test") }
                        );
            dataSession.AddSet(new UserForgotPassword() { Code = "2s86khVAgN", UserID = 1 });

            _controller = new AccountController(dataSession, new AuthenticationHelper());

            StructuremapMvc.Start();
            MvcApp.Mappings.AutoMapperConfiguration.Setup();
        }

        [TestMethod]
        public void AccountIndex()
        {
            ViewResult result = _controller.Index() as ViewResult;
            ControllerHelper.AssertController(result, _controller);
        }
        
        [TestMethod]
        public void AccountRegisterPost()
        {
            var result = _controller.Register(new ViewModels.Account.RegisterViewModel()
            {
                Username = "",
                Password = "T3stingT3sting",
                ConfirmPassword = "T3stingT3sting",
                Email = "testing@testy.com"
            });

            ControllerHelper.AssertController(result, _controller);
        }

        [TestMethod]
        public void AccountRegister()
        {
            ViewResult result = _controller.Register() as ViewResult;
            ControllerHelper.AssertController(result, _controller);
        }

        [TestMethod]
        public void AccountLogin()
        {
            ViewResult result = _controller.Login("test") as ViewResult;
            ControllerHelper.AssertController(result, _controller);
        }

        [TestMethod]
        public void AccountLoginPost()
        {
            var result = _controller.Login(new LoginViewModel() { UserName = "akeelm", Password = "test" }, null);
            ControllerHelper.AssertController(result, _controller);

            //Need to be able to login using e-mail address as well as username
            result = _controller.Login(new LoginViewModel() { UserName = "akeel@email.com", Password = "test" }, null);
            ControllerHelper.AssertController(result, _controller);
        }

        [TestMethod]
        public void AccountForgotPassword()
        {
            var result = _controller.ForgotPassword();
            ControllerHelper.AssertController(result, _controller);
        }

        [TestMethod]
        public void AccountForgotPasswordPost()
        {
            var result = _controller.ForgotPassword(new UserForgotPasswordViewModel() { Email = "akeel@email.com" });
            ControllerHelper.AssertController(result, _controller);
        }

        [TestMethod]
        public void AccountResetPassword()
        {
            throw new NotImplementedException();
            //_controller.AccountReset("akeel@email.com", "2s86khVAgN");
        }
    }
}
