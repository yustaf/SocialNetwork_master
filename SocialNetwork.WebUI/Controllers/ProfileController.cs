using System.Web.Mvc;
using SocialNetwork.BuisnessLayer.Abstract;

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
    }
}