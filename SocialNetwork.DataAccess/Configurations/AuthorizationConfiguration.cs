using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Domain.Models;


namespace SocialNetwork.DataAccess.Configurations
{
    public class AuthorizationConfiguration : EntityTypeConfiguration<Authorization>
    {
        public AuthorizationConfiguration()
        {
            ToTable("Authorization");
            HasKey(p => p.Id);
            Property(p => p.Login).IsRequired();
            Property(p => p.Password).IsRequired();
            HasRequired(p => p.Profile).WithRequiredPrincipal(p => p.Authorization);
        }
    }
}
