using SocialNetwork.BuisnessLayer.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SocialNetwork.BuisnessLayer.DataService
{
    public class ProfileDataService : IProfileDataService
    {
        private readonly IRepository<Authorization> _authRepository;
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<FriendEntity> _friendRepository;
        private readonly IRepository<MessageEntity> _messageRepository;
        private readonly IRepository<DialogEntity> _dialogRepository;

        public ProfileDataService(IRepository<Authorization> authRepository, IRepository<Profile> profileRepository, IRepository<FriendEntity> friendRepository, IRepository<MessageEntity> messageRepository, IRepository<DialogEntity> dialogRepository)
        {
            _authRepository = authRepository;
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
            _messageRepository = messageRepository;
            _dialogRepository = dialogRepository;
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return _profileRepository.GetAllQuery().ToList();
        }

        public int GetCountFriends(string UserId)
        {
            var user = _profileRepository.Find(p => p.Id == UserId);
            return user.Friends.Count();
        }

        public IEnumerable<FriendEntity> GetUserFriends(string UserId)
        {
            return _friendRepository.Filter(p => p.UserId == UserId)                
                .Select(
                p => new FriendEntity()
                {                    
                    Friend = p.Friend    
                }).ToList();
        }

        public IEnumerable<DialogEntity> GetUserDialog(string UserId)
        {
            return _dialogRepository.Filter(p => p.UserToId == UserId)                
                .Select(
                p => new DialogEntity()
                {
                    UserFromId = p.UserFromId,
                    UserFrom = p.UserFrom,
                    UserToId = p.UserToId,
                    UserTo = p.UserTo
                }).ToList();
        }

        public int GetCountMessages(string UserToId, string UserFromId)
        {
            var message = _dialogRepository.Find(p => p.UserToId == UserToId && p.UserFromId==UserFromId);
            return message.Messages.Count();
        }

        public void DeleteAllUsers()
        {
            var list = _profileRepository.GetAllQuery();
            _profileRepository.RemoveRange(list);
            _profileRepository.SaveChanges();
        }

        public Profile GetUserAllInfo(string Id)
        {
            return _profileRepository.FindByKey(Id);
        }

        public IEnumerable<Profile> Search(string Name)
        {
            var ProfileList = _profileRepository.GetAll();
            var SearchList = new List<Profile>();
            IEnumerable<Profile> List;
            if (Name == "")
            {
                return List = ProfileList;
            }
            foreach (var profile in ProfileList)
            {
                if (profile.FirstName == Name || profile.LastName == Name || profile.PatronymicName == Name)
                {
                    SearchList.Add(profile);
                }
            }
            return List = SearchList;
        }
    }
}