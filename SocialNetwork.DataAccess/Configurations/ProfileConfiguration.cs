using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Domain.Models;


namespace SocialNetwork.DataAccess.Configurations
{
    public class ProfileConfiguration : EntityTypeConfiguration<Profile>
    {
        public ProfileConfiguration()
        {
            ToTable("Profile");
            Property(p => p.FirstName).IsRequired();
            Property(p => p.LastName).IsRequired();
            Property(p => p.PatronymicName).IsRequired();
            Property(p => p.Birthday).IsRequired();
            Property(p => p.City).IsRequired();
            Property(p => p.Contact).IsRequired();

            HasMany(p => p.Users).WithRequired(p => p.User).HasForeignKey(p => p.UserId).WillCascadeOnDelete(false);
            HasMany(p => p.Friends).WithRequired(p => p.Friend).HasForeignKey(p => p.FriendId).WillCascadeOnDelete(false);

            HasMany(p => p.UsersTo).WithRequired(p => p.UserTo).HasForeignKey(p => p.UserToId).WillCascadeOnDelete(false);
            HasMany(p => p.UsersFrom).WithRequired(p => p.UserFrom).HasForeignKey(p => p.UserFromId).WillCascadeOnDelete(false);
        }
    }
}
