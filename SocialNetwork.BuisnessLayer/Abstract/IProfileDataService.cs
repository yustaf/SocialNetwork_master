using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IProfileDataService
    {

        IEnumerable<Profile> GetProfiles();
        
        int GetCountFriends(int UserId);

        IEnumerable<FriendEntity> GetUserFriends(int UserId);

        IEnumerable<MessageEntity> GetUserMessages(int UserId);

        int GetCountMessages(int UserToId, int UserFromId);
    }
}
