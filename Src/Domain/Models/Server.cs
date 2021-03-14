namespace Domain.Models
{
    public class Server : AuditableEntity 
    {
        private Server(string id, string name, string ownerId)
        {
            Id = id;
            Name = name;
            OwnerId = ownerId;
        }

        public Server(string name, ApplicationUser owner)
        {
            Name = name;
            Owner = owner;
        }
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string OwnerId { get; set; } = null!;

        public ApplicationUser Owner { get; set; } = null!;
    }
}