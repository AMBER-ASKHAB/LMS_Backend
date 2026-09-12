using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum UserStatus : byte
    {
        Active = 0,
        Blocked = 1,
        Locked = 2,
        PendingVerification = 3
    }
}
