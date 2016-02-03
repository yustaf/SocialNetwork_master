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
using System.Threading.Tasks;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileDataService _profileDataService;

        public ProfileController(IProfileDataService profileDataService)
        {
            _profileDataService = profileDataService;
        }

        public ViewResult Index()
        {
            var user = _profileDataService.GetProfiles();
            return View(user);
        }
        public ActionResult viewingUsers(string Id)
        {
            return View(_profileDataService.GetUserAllInfo(Id));
        }
        public ViewResult ProfileSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProfileSearch(string name)
        {
            var AllProfile = _profileDataService.Search(name);
            if (AllProfile.Count() <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(AllProfile);
        }

    }
}