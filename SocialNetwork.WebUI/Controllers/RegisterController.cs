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
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace SocialNetwork.WebUI.Controllers
{
    public class RegisterController : Controller
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
        public async Task<ActionResult> Index(Authorization model)
        {
            if (ModelState.IsValid)
            {
                Authorization user = new Authorization {UserName = model.Login, Login = model.Login, Password = model.Password };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _authDataService.add(user.Id, model.Profile.FirstName,  model.Profile.LastName, model.Profile.PatronymicName,model.Profile.Birthday, model.Profile.City, model.Profile.Contact);
                    return RedirectToAction("Index", "Authorization");
                }
                else
                {
                    return RedirectToAction("Index", "Message");
                    /*foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }*/
                }
            }
            return View(model);
        }
    }
}