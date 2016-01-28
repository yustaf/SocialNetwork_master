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

        public ViewResult Index()
        {
            var auth = _authDataService.GetAuthorizations();
            return View(auth);
        }
    }
}