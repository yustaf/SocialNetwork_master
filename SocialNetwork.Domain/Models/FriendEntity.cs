using System;

namespace SocialNetwork.Domain.Models
{
    public class FriendEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Profile User { get; set; }
        public virtual Profile Friend { get; set; }
    }
}
