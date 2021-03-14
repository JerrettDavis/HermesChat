using Domain.Models;
using Infrastructure.Common.Genetators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasValueGenerator<IdValueGenerator>();
        }
    }
}