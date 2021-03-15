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