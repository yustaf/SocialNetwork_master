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

        public IEnumerable<FriendEntity> MyFriendsList(string Id)
        {
            var Friends = _friendRepository.GetAll();
            var UsersList = new List<FriendEntity>();
            foreach (var friend in Friends)
            {
                if (friend.FriendId == Id)
                {
                    UsersList.Add(friend);
                }
            }
            return UsersList;
        }

        public IEnumerable<Profile> GetAllFriends(string Id)
        {
            
            var FriendList = new List<Profile>();
            IEnumerable < FriendEntity > UsersList = MyFriendsList(Id);
            foreach (var frind in UsersList)
            {
                if(frind.Id != "0")
                {                    
                    FriendList.Add(frind.Friend);
                }
            }
            IEnumerable<Profile> List = FriendList;
            return List;
        }

        public void AddFriend(string UserId, string FriendId)
        {
            var KeyFriend = new { FriendId, UserId };
            var Application = _friendRepository.FindByKey(KeyFriend);

            if (Application != null && Application.Id == "0")
            {
                _friendRepository.Delete(Application);
                FriendEntity AddFriend = new FriendEntity { Id = UserId, UserId = UserId, FriendId = FriendId, DateCreated = DateTime.Now };
                FriendEntity AddApplication = new FriendEntity { Id = FriendId, UserId = FriendId, FriendId = UserId, DateCreated = DateTime.Now };
                _friendRepository.Add(AddFriend);
                _friendRepository.Add(AddApplication);
                _friendRepository.SaveChanges();
            }
            else
            {
                FriendEntity addfriend = new FriendEntity { Id = "0", UserId = UserId, FriendId = FriendId, DateCreated = DateTime.Now };
                _friendRepository.Add(addfriend);
                _friendRepository.SaveChanges();
            }
            
        }

        public IEnumerable<Profile> GetMyFollowers(string Id)
        {
            var FriendList = new List<Profile>();
            IEnumerable<FriendEntity> UsersList = MyFriendsList(Id);
            foreach (var frind in UsersList)
            {
                if (frind.Id == "0")
                {
                    FriendList.Add(frind.Friend);
                }
            }
            IEnumerable<Profile> List = FriendList;
            return List;
        }

       
    }
}
