using System;
namespace SocialNetwork.Domain.Models
{
    public class MessageEntity
    {
        public string Id { get; set; }
        public string DialogId { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public virtual DialogEntity Dialog { get; set; }
    }
}
