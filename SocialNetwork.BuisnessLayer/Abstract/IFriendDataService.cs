using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IFriendDataService
    {
        IEnumerable<FriendEntity> GetAllFriends();
    }
}
