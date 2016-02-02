using System.Web.Mvc;
using SocialNetwork.BuisnessLayer.Abstract;
using System.Web;
using SocialNetwork.DataAccess.Context;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace SocialNetwork.WebUI.Controllers
{
    public class FriendController : Controller
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
        public ViewResult AddFriend(string Id)
        {
            _friendDataService.AddFriend(User.Identity.GetUserId(), Id);
            return View();
        }
    }
}