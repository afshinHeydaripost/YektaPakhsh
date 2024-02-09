using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ProductGroup : BaseEntity
{

    public string Code { get; set; }

    public string Title { get; set; }

    public int? ParentId { get; set; }

    public string UserId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual AspNetUser User { get; set; }
}
