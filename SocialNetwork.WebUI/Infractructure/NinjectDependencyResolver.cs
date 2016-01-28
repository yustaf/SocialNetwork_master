using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using SocialNetwork.Domain.Models;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Repositories;
using SocialNetwork.BuisnessLayer.Abstract;
using SocialNetwork.BuisnessLayer.DataService;

namespace SocialNetwork.WebUI.Infractructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IRepository<Authorization>>().To<Repository<Authorization>>();
            kernel.Bind<IRepository<Profile>>().To<Repository<Profile>>();
            kernel.Bind<IRepository<FriendEntity>>().To<Repository<FriendEntity>>();
            kernel.Bind<IRepository<MessageEntity>>().To<Repository<MessageEntity>>();
            kernel.Bind<IAuthDataService>().To<AuthDataService>();
            kernel.Bind<IProfileDataService>().To<ProfileDataService>();
            kernel.Bind<IMessageDataService>().To<MessageDataService>();
            kernel.Bind<IFriendDataService>().To<FriendDataService>();
        }
    }
}