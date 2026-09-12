using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Auth
{
    public class AuditLog
    {
        public long AuditLogId { get; set; }
        public long? UserId { get; set; }
        public User? User { get; set; }
        public string Action { get; set; } = null!;
        public string? IPAddress { get; set; }
        public string? Details { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
