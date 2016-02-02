using System.Web.Mvc;
using SocialNetwork.BuisnessLayer.Abstract;

namespace SocialNetwork.WebUI.Controllers
{
    public class FriendController : Controller
    {
        private readonly IFriendDataService _friendDataService;
        private readonly IProfileDataService _profileDataService;
        
        public FriendController(IFriendDataService friendDataService, IProfileDataService profileDataService)
        {
            _friendDataService = friendDataService;
            _profileDataService = profileDataService;
        }

        public ViewResult Index()
        {
            var friends = _profileDataService.GetProfiles();
            return View(friends);
        }
    }
}