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
        private readonly IRepository<DialogEntity> _dialogRepository;

        public FriendDataService(IRepository<Authorization> authRepository, IRepository<Profile> profileRepository, IRepository<FriendEntity> friendRepository, IRepository<MessageEntity> messageRepository, IRepository<DialogEntity> dialogRepository)
        {
            _authRepository = authRepository;
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
            _messageRepository = messageRepository;
            _dialogRepository = dialogRepository;
        }

        public IEnumerable<FriendEntity> MyFriendsList(string Id)
        {
            var Friends = _friendRepository.GetAll();
            var UsersList = new List<FriendEntity>();
            foreach (var friend in Friends)
            {
                if (friend.FriendId == Id || friend.UserId == Id)
                {
                    UsersList.Add(friend);
                }
            }
            return UsersList;
        }

        public IEnumerable<Profile> GetAllFriends(string Id)
        {
            var Friends = _friendRepository.GetAll();
            var UsersList = new List<Profile>();
            foreach (var friend in Friends)
            {
                if (friend.UserId == Id && friend.Id == Id)
                {
                    UsersList.Add(friend.Friend);
                }
            }
            IEnumerable<Profile> List = UsersList;
            return List;
        }

        public void AddFriend(string UserId, string FriendId)
        {
            var Application = _friendRepository.FindByKey(new object[] { FriendId, UserId });

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
            var Friends = _friendRepository.GetAll();
            var UsersList = new List<Profile>();
            foreach (var friend in Friends)
            {
                if (friend.FriendId == Id && friend.Id == "0")
                {
                    UsersList.Add(_profileRepository.FindByKey(friend.UserId));
                }
            }
            IEnumerable<Profile> List = UsersList;
            return List;
        }

        public IEnumerable<Profile> GetIFollowers(string Id)
        {
            var Friends = _friendRepository.GetAll();
            var UsersList = new List<Profile>();
            foreach (var friend in Friends)
            {
                if (friend.UserId == Id && friend.Id == "0")
                {
                    UsersList.Add(_profileRepository.FindByKey(friend.FriendId));
                }
            }
            IEnumerable<Profile> List = UsersList;
            return List;
        }
    }
}
