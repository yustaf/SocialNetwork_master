using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IProfileDataService
    {

        IEnumerable<Profile> GetProfiles();
        
        int GetCountFriends(string UserId);

        IEnumerable<FriendEntity> GetUserFriends(string UserId);

        IEnumerable<MessageEntity> GetUserMessages(string UserId);

        int GetCountMessages(string UserToId, string UserFromId);
    }
}
