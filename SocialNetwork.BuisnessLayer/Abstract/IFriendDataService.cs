using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IFriendDataService
    {
        IEnumerable<Profile> GetAllFriends(string Id);
        void AddFriend(string UserId, string FriendId);

    }
}
