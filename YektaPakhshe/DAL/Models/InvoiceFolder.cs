using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class InvoiceFolder : BaseEntity
{

    public int InvoiceId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal? DiscountRate { get; set; }

    public decimal DiscountPrice { get; set; }

    public decimal TaxPrice { get; set; }

    public decimal TaxTollPrice { get; set; }

    public decimal TotalNetPrice { get; set; }

    public string Reference { get; set; }

    public virtual Invoice Invoice { get; set; }

    public virtual Product Product { get; set; }
}
