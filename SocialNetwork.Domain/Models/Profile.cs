using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Models
{
    public class Profile
    {
        public Profile()
        {
            Users = new List<FriendEntity>();
            Friends = new List<FriendEntity>();
            UsersTo = new List<DialogEntity>();
            UsersFrom = new List<DialogEntity>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        
        public virtual Authorization Authorization { get; set; }
        public virtual ICollection<FriendEntity> Users { get; set; }
        public virtual ICollection<FriendEntity> Friends { get; set; }
        public virtual ICollection<DialogEntity> UsersTo { get; set; }
        public virtual ICollection<DialogEntity> UsersFrom { get; set; }
    }
}
