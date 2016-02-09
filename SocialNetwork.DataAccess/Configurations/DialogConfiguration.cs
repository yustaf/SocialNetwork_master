using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.DataAccess.Configurations
{
    public class DialogConfiguration : EntityTypeConfiguration<DialogEntity>
    {
        public DialogConfiguration()
        {
            ToTable("DialogEntity");
            HasKey(k => new { k.UserToId, k.UserFromId });
            HasRequired(x => x.UserTo);
            HasRequired(x => x.UserFrom);

            HasKey(p => p.Id);
            HasMany(x => x.Messages);


        }
    }
}
