using System;
namespace SocialNetwork.Domain.Models
{
    public class MessageEntity
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string UserToId { get; set; }
        public string UserFromId { get; set; }
        public virtual Profile UserFrom { get; set; }
        public virtual Profile UserTo { get; set; }
    }
}
