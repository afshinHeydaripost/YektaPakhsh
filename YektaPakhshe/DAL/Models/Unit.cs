using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Unit : BaseEntity
{

    public string Code { get; set; }

    public string Title { get; set; }

    public string UserId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public string TaxReferenceId { get; set; }

    public virtual AspNetUser User { get; set; }
}
