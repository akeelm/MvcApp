using System.Web.Mvc;
using MvcApp.ViewModels.Account;
using System.Threading.Tasks;
using Repository.Data;
using AutoMapper;
using Repository.Models;
using MvcApp.Services.Security;
using System;

namespace MvcApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UsersService _usersService;
        private UserForgotPasswordService _userForgotPasswordService;
        private IAuthentication _authentication;

        public AccountController(IDataSession dataSession, IAuthentication authentication)
        {
            _usersService = new UsersService(dataSession);
            _userForgotPasswordService = new UserForgotPasswordService(dataSession);
            _authentication = authentication;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Repository.Models.User user;
                //if submitted e-mail address, get the username
                if (model.UserName.Contains("@"))
                    user = _usersService.GetUserByEmail(model.UserName);
                else
                    user = _usersService.GetUserByUsername(model.UserName);

                if (user != null && PasswordHash.ValidatePassword(model.Password, user.Password))
                {
                    _authentication.Login(user, true);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<User>(model);

                if (_usersService.GetUserByUsername(user.Username) != null)
                {
                    ModelState.AddModelError("", "This username already exists.\n\nPlease try another username.");
                }
                else if (_usersService.GetUserByEmail(user.Email) != null)
                {
                    ModelState.AddModelError("",
                        string.Format("This E-mail address has already been registered.\n\nIf this is your e-mail address, click <a href=\"{0}\">here</a> to reset.", Services.SiteInfo.FORGOT_PASSWORD_LINK));
                }
                else
                {
                    var newUser = _usersService.AddReturnEntity(user);
                    if (ModelState.IsValid)
                    {
                        _authentication.Login(newUser, true);
                        return RedirectToAction("Index", "Home");
                    }
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(UserForgotPasswordViewModel model)
        {
            var user = _usersService.GetUserByEmail(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "This e-mail address doesn't exist."); 
            }
            else
            {
                var userForgotPassword = Mapper.Map<UserForgotPassword>(model);
                userForgotPassword.User = user;
                _userForgotPasswordService.Add(userForgotPassword);
                //TODO:Email a link
                TempData["Success"] = "A reset link has been sent to your e-mail address.";
                return View();
            }
            return View(model);
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url != null && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}