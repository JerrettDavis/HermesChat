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

using Domain.Common.Attributes;

// ReSharper disable MemberInitializerValueIgnored

namespace Domain.Models
{
    [IsEntity]
    public class ServerUser : AuditableEntity
    {
        private ServerUser(string serverId, string userId)
        {
            ServerId = serverId;
            UserId = userId;
        }

        public ServerUser(Server server, ApplicationUser user) :
            this(server.Id, user.Id)
        {
            Server = server;
            User = user;
        }

        public string ServerId { get; }
        public string UserId { get; }

        public Server Server { get; } = null!;
        public ApplicationUser User { get; } = null!;
    }
}