using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AspNetUserClaim : BaseEntity
{
    public string UserId { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }

    public virtual AspNetUser User { get; set; }
}
