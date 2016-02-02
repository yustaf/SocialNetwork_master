using SocialNetwork.BuisnessLayer.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SocialNetwork.BuisnessLayer.DataService
{
    public class FriendDataService : IFriendDataService
    {
        private readonly IRepository<Authorization> _authRepository;
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<FriendEntity> _friendRepository;
        private readonly IRepository<MessageEntity> _messageRepository;

        public FriendDataService(IRepository<Authorization> authRepository, IRepository<Profile> profileRepository, IRepository<FriendEntity> friendRepository, IRepository<MessageEntity> messageRepository)
        {
            _authRepository = authRepository;
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
            _messageRepository = messageRepository;
        }

        public IEnumerable<FriendEntity> GetAllFriends()
        {
            return _friendRepository.GetAllQuery().ToList();
        }

        public void AddFriend(string UserId, string FriendId)
        {
            FriendEntity addfriend = new FriendEntity { Id = UserId, UserId = FriendId, FriendId = FriendId, DateCreated = DateTime.Today };
            _friendRepository.Add(addfriend);
            _friendRepository.SaveChanges();
        }
    }
}
