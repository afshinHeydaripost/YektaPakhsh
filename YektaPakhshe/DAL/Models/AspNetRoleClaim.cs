using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AspNetRoleClaim : BaseEntity
{

    public string RoleId { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }

    public virtual AspNetRole Role { get; set; }
}
