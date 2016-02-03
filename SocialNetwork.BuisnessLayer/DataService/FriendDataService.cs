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

        public IEnumerable<Profile> GetAllFriends(string Id)
        {
            var Profile = _profileRepository.FindByKey(Id);
            IEnumerable<FriendEntity> UsersList = Profile.Friends.ToList();
            var FriendList = new List<Profile>();
            foreach (var frind in UsersList)
            {
                if(frind.FriendId == frind.UserId)
                {                    
                    
                    FriendList.Add(frind.Friend);
                }
            }
            IEnumerable<Profile> List = FriendList;
            return List;
        }

        public void AddFriend(string UserId, string FriendId)
        {
            FriendEntity addfriend = new FriendEntity { Id = UserId, UserId = FriendId, FriendId = FriendId, DateCreated = DateTime.Today };
            _friendRepository.Add(addfriend);
            _friendRepository.SaveChanges();
        }
    }
}
