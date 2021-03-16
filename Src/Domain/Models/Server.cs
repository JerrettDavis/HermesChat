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

using System.Collections.Generic;
using Domain.Common.Attributes;

// ReSharper disable MemberInitializerValueIgnored

namespace Domain.Models
{
    [IsEntity]
    public class Server : AuditableEntity
    {
        private Server(string id, string name, string ownerId)
        {
            ServerUsers = new HashSet<ServerUser>();

            Id = id;
            Name = name;
            OwnerId = ownerId;
        }

        public Server(string name, ApplicationUser owner) :
            this(null!, name, owner.Id)
        {
            Name = name;
            Owner = owner;
        }

        public string Id { get; } = null!;
        public string Name { get; set; }
        public string OwnerId { get; set; } = null!;

        public ApplicationUser Owner { get; set; } = null!;

        public ICollection<ServerUser> ServerUsers { get; }

        public void AddUser(ApplicationUser user)
        {
            ServerUsers.Add(new ServerUser(this, user));
        }

        protected bool Equals(Server other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Server) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}