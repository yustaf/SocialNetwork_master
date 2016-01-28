using System.Web.Mvc;
using SocialNetwork.BuisnessLayer.Abstract;

namespace SocialNetwork.WebUI.Controllers
{
    public class FriendController : Controller
    {
        private readonly IFriendDataService _friendDataService;

        public FriendController(IFriendDataService friendDataService)
        {
            _friendDataService = friendDataService;
        }

        public ViewResult Index()
        {
            var friends = _friendDataService.GetAllFriends();
            return View(friends);
        }
    }
}