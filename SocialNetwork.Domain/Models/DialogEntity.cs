using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Models
{
    public class DialogEntity
    {
        public DialogEntity()
        {
            Messages = new List<MessageEntity>();
        }
        public string Id { get; set; }
        public string UserToId { get; set; }
        public string UserFromId { get; set; }
        public virtual Profile UserFrom { get; set; }
        public virtual Profile UserTo { get; set; }
        public virtual ICollection<MessageEntity> Messages { get; set; }
    }
}
