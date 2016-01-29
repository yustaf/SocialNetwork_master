using System.Web.Mvc;
using SocialNetwork.BuisnessLayer.Abstract;

namespace SocialNetwork.WebUI.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthDataService _authDataService;

        public AuthorizationController(IAuthDataService authDataService)
        {
            _authDataService = authDataService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}