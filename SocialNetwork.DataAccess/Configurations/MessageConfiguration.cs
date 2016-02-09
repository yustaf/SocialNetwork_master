using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Domain.Models;


namespace SocialNetwork.DataAccess.Configurations
{
    public class MessageConfiguration : EntityTypeConfiguration<MessageEntity>
    {
        public MessageConfiguration()
        {
            ToTable("MessageEntity");
            HasKey(p => p.Id);
            Property(p => p.DateTime).IsRequired();
            Property(p => p.Message).IsRequired();

            HasRequired(p => p.Dialog).WithMany(p => p.Messages).HasForeignKey(p => p.DialogId).WillCascadeOnDelete(false);
        }
    }
}
