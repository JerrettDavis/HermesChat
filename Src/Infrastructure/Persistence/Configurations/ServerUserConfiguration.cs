using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ServerUserConfiguration : IEntityTypeConfiguration<ServerUser>
    {
        public void Configure(EntityTypeBuilder<ServerUser> builder)
        {
            builder.HasKey(e => new {e.ServerId, e.UserId});
            builder.HasOne(e => e.User)
                .WithMany(e => e.ServerUsers)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Server)
                .WithMany(e => e.ServerUsers)
                .HasForeignKey(e => e.ServerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}