using SocialNetwork.BuisnessLayer.Abstract;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SocialNetwork.BuisnessLayer.DataService
{
    public class DialogDataService : IDialogDataService
    {
        private readonly IRepository<Authorization> _authRepository;
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<FriendEntity> _friendRepository;
        private readonly IRepository<MessageEntity> _messageRepository;
        private readonly IRepository<DialogEntity> _dialogRepository;

        public DialogDataService(IRepository<Authorization> authRepository, IRepository<Profile> profileRepository, IRepository<FriendEntity> friendRepository, IRepository<MessageEntity> messageRepository, IRepository<DialogEntity> dialogRepository)
        {
            _authRepository = authRepository;
            _profileRepository = profileRepository;
            _friendRepository = friendRepository;
            _messageRepository = messageRepository;
            _dialogRepository = dialogRepository;
        }

    }
}
