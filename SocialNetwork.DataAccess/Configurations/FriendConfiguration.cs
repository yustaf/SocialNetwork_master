using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.DataAccess.Configurations
{
    public class FriendConfiguration : EntityTypeConfiguration<FriendEntity>
    {
        public FriendConfiguration()
        {
            ToTable("FriendEntity");
            HasKey(k => new { k.UserId, k.FriendId });
            HasRequired(x => x.User);
            HasRequired(x => x.Friend);            
        }
    }
}
