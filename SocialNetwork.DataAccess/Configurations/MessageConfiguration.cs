using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Domain.Models;


namespace SocialNetwork.DataAccess.Configurations
{
    public class MessageConfiguration : EntityTypeConfiguration<MessageEntity>
    {
        public MessageConfiguration()
        {
            ToTable("MessageEntity");
            Property(p => p.DateTime).IsRequired();
            Property(p => p.Message).IsRequired();
        }
    }
}
