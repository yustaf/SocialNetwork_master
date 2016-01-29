using System.Web.Mvc;
using SocialNetwork.BuisnessLayer.Abstract;
using System.Threading.Tasks;
using System.Web;
using System;
using SocialNetwork.Domain.Models;
using SocialNetwork.DataAccess.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace SocialNetwork.WebUI.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthDataService _authDataService;

        public AuthorizationController(IAuthDataService authDataService)
        {
            _authDataService = authDataService;
        }
        private SocialNetworkManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<SocialNetworkManager>();
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Authorization model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Authorization user = await UserManager.FindAsync(model.Login, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}