using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaWarehouse.Api.Modules.JwtToken
{
    public enum ClaimType
    {
        UserId = 0,
        FirstName = 1,
        LastName = 2,
        Role = 3,
        RoleId = 4,
        TokenExpireDate = 5,
    }
}
