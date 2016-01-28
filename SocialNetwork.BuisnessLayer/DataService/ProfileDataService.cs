using SocialNetwork.BuisnessLayer.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.BuisnessLayer.DataService
{
    public class ProfileDataService : IProfileDataService
    {
        private readonly IRepository<Authorization> _authRepository;
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<FriendEntity> _friendRepository;
        private readonly IRepository<MessageEntity> _messageRepository;
        
        public ProfileDataService(IRepository<Authorization> authRepository, IRepository<Profile> profileRepository, IRepository<FriendEntity> friendRepository, IRepository<MessageEntity> messageRepository)
        {
            _authRepository = authRepository;
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
            _messageRepository = messageRepository;
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return _profileRepository.GetAllQuery().ToList();
        }

        public int GetCountFriends(int UserId)
        {
            var user = _profileRepository.Find(p => p.Id == UserId);
            return user.Friends.Count();
        }

        public IEnumerable<FriendEntity> GetUserFriends(int UserId)
        {
            return _friendRepository.Filter(p => p.UserId == UserId)                
                .Select(
                p => new FriendEntity()
                {                    
                    Friend = p.Friend    
                }).ToList();
        }

        public IEnumerable<MessageEntity> GetUserMessages(int UserId)
        {
            return _messageRepository.Filter(p => p.UserToId == UserId)                
                .Select(
                p => new MessageEntity()
                {
                    UserFromId = p.UserFromId,
                    UserFrom = p.UserFrom,
                    UserToId = p.UserToId,
                    UserTo = p.UserTo,
                    DateTime = p.DateTime,
                    Message = p.Message
                }).ToList();
        }

        public int GetCountMessages(int UserToId, int UserFromId)
        {
            var message = _messageRepository.Find(p => p.UserToId == UserToId && p.UserFromId==UserFromId);
            return message.Message.Count();
        }
    }
}