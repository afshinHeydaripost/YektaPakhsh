using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class UserAccessProduct : BaseEntity
{

    public string UserId { get; set; }

    public int ProductId { get; set; }
}
