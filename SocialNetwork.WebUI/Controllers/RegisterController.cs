using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.Domain.Models;
using SocialNetwork.BuisnessLayer.Abstract;
using SocialNetwork.DataAccess.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace SocialNetwork.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private SocialNetworkManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<SocialNetworkManager>();
            }
        }

        private readonly IAuthDataService _authDataService;

        public RegisterController(IAuthDataService authDataService)
        {
            _authDataService = authDataService;
        }

        public ActionResult Index()
        {
            /*var auth = _authDataService.GetAuthorizations();
            return View(auth);*/
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Authorization model)
        {
            if (ModelState.IsValid)
            {
                Authorization user = new Authorization { Login = model.Login, Password = model.Password };
                Profile profil = new Profile { FirstName = model.Profile.FirstName, LastName = model.Profile.LastName, PatronymicName = model.Profile.PatronymicName, Birthday = model.Profile.Birthday, City = model.Profile.City, Contact = model.Profile.Contact };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }
    }
}