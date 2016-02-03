using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.DataAccess.Context;
using Microsoft.Owin.Security;
using SocialNetwork.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SocialNetwork.BuisnessLayer.Abstract;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SocialNetwork.WebUI.Controllers
{
    public class ManageController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private SocialNetworkManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<SocialNetworkManager>();
            }
        }
        private readonly IAuthDataService _authDataService;

        public ManageController(IAuthDataService authDataService)
        {
            _authDataService = authDataService;
        }

        public ViewResult Index()
        {
            return View();
        }
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                }
            }
            return View(model);
        }

        public ActionResult ChangeInfoProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangeInfoProfileAjax(Profile model)
        {
            Authorization user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                user.Profile.FirstName = model.FirstName;
                user.Profile.LastName = model.LastName;
                user.Profile.PatronymicName = model.PatronymicName;
                user.Profile.Birthday = model.Birthday;
                user.Profile.City = model.City;
                user.Profile.Contact = model.Contact;
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Json(new { resultMessage = "Данные профиля изменены" });
                }
                else
                {
                    return Json(new { resultMessage = "Данные профиля не изменены" });
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return View(model);
        }
    }
}