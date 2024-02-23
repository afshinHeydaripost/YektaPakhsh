using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PreInvoiceFolder : BaseEntity
{
    public int PreInvoiceId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal TaxPrice { get; set; }

    public decimal TotalNetPrice { get; set; }

    public string Reference { get; set; }

    public virtual PreInvoice PreInvoice { get; set; }

    public virtual Product Product { get; set; }
}
