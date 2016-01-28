using SocialNetwork.Domain.Models;
using System.Data.Entity;
using SocialNetwork.DataAccess.Configurations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SocialNetwork.DataAccess.Context
{
    public class SocialNetworkContext : IdentityDbContext<Authorization>
    {

        public SocialNetworkContext() : base("SocialNetworkDB") { }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<FriendEntity> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorizationConfiguration());
            modelBuilder.Configurations.Add(new ProfileConfiguration());
            modelBuilder.Configurations.Add(new FriendConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public static SocialNetworkContext Create()
        {
            return new SocialNetworkContext();
        }
    }
}
