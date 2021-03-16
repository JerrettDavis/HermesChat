// HermesChat - Simple real-time chat application.
// Copyright (C) 2021  Jerrett D. Davis
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

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