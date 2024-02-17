using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Product : BaseEntity
{

    public int? ProductGroupId { get; set; }

    public string Code { get; set; }

    public string Title { get; set; }

    public int UnitId { get; set; }

    public string Description { get; set; }

    public bool Disabled { get; set; }

    public string PictureImg { get; set; }

    public string UserId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public short? BrandTypeId { get; set; }

    public virtual ICollection<InvoiceFolder> InvoiceFolders { get; set; } = new List<InvoiceFolder>();

    public virtual ICollection<PreInvoiceFolder> PreInvoiceFolders { get; set; } = new List<PreInvoiceFolder>();

    public virtual ProductGroup ProductGroup { get; set; }
    public virtual Unit Unit{ get; set; }

    public virtual AspNetUser User { get; set; }
}
