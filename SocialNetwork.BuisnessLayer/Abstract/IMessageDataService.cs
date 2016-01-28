using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IMessageDataService
    {
        IEnumerable<MessageEntity> GetAllMessages();
    }
}
