using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IFriendDataService
    {
        IEnumerable<Profile> GetAllFriends(string Id);
        IEnumerable<FriendEntity> MyFriendsList(string Id);
        IEnumerable<Profile> GetMyFollowers(string Id);
        void AddFriend(string UserId, string FriendId);

    }
}
