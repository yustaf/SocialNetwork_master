using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SocialNetwork.Domain.Models
{
    public class Authorization : IdentityUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
