using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.DataAccess.Context;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SocialNetwork.BuisnessLayer.Abstract;

namespace SocialNetwork.WebUI.Controllers
{
    public class HomeController : Controller
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

        public HomeController(IAuthDataService authDataService)
        {
            _authDataService = authDataService;
        }
        public ActionResult Index()
        {
            var user = _authDataService.GetUserAllInfo(User.Identity.GetUserId());
            return View(user);
        }
    }
}