using System.Web.Mvc;
using SocialNetwork.BuisnessLayer.Abstract;

namespace SocialNetwork.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageDataService _messageDataService;
        
        public MessageController(IMessageDataService messageDataService)
        {
            _messageDataService=messageDataService;
        }

        public ViewResult Index()
        {
            var messages =_messageDataService.GetAllMessages();
            return View(messages);
        }
    }
}