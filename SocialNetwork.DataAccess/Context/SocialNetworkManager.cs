using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;

namespace SocialNetwork.DataAccess.Context
{
    public class SocialNetworkManager :UserManager<Authorization>
    {
        public SocialNetworkManager(IUserStore<Authorization> store) : base(store) 
        {
        }
        public static SocialNetworkManager Create(IdentityFactoryOptions<SocialNetworkManager> options,
                                            IOwinContext context)
        {
            SocialNetworkContext db = context.Get<SocialNetworkContext>();
            SocialNetworkManager manager = new SocialNetworkManager(new UserStore<Authorization>(db));
            return manager;
        }
    }
}
