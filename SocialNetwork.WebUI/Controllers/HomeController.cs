using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.DataAccess.Context;

namespace SocialNetwork.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public SocialNetworkContext context = new SocialNetworkContext();
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to SocialNetwork";
            return View();
        }
    }
}