using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Auth
{
    public class ExternalLogin
    {
        public long ExternalLoginId { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public string Provider { get; set; } = null!;      // "Google"
        public string ProviderKey { get; set; } = null!;    // Google's "sub" claim
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
