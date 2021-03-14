using System;

namespace Application.Common.Models
{
    public class AuditableDto
    {
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}