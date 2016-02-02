using SocialNetwork.BuisnessLayer.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SocialNetwork.BuisnessLayer.DataService
{
    public class AuthDataService : IAuthDataService
    {
        private readonly IRepository<Authorization> _authRepository;
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<FriendEntity> _friendRepository;
        private readonly IRepository<MessageEntity> _messageRepository;

        public AuthDataService(IRepository<Authorization> authRepository, IRepository<Profile> profileRepository, IRepository<FriendEntity> friendRepository, IRepository<MessageEntity> messageRepository)
        {
            _authRepository = authRepository;
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
            _messageRepository = messageRepository;
        }

        public IEnumerable<Authorization> GetAuthorizations()
        {
            return _authRepository.GetAllQuery().ToList();
        }

        public void add(string Id, string FirstName, string LastName, string PatronymicName, DateTime birthday, string City, string Contact)
        {
            
            Profile prof = new Profile { Id = Id, FirstName = FirstName, LastName = LastName, PatronymicName = PatronymicName, Birthday = birthday, City = City, Contact = Contact };
            _profileRepository.Add(prof);
            _profileRepository.SaveChanges();
        }

        public Authorization GetUserAllInfo(string Id)
        {
            return _authRepository.FindByKey(Id);
        }

        public void DeleteAllUsers()
        {
            var list = _authRepository.GetAllQuery();
            _authRepository.RemoveRange(list);
            _authRepository.SaveChanges();

        }
    }
}
