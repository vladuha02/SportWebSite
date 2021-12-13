using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportWebSite.Domain.Entities;

namespace SportWebSite.Data.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(o => o.Team)
              .WithMany(o => o.Players)
              .HasForeignKey(o => o.TeamId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
