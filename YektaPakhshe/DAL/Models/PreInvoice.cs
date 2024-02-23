using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PreInvoice : BaseEntity
{

    public string PreInvoiceNo { get; set; }

    public DateTime PreInvoiceDate { get; set; }

    public int PersonId { get; set; }

    public decimal? DiscountRate { get; set; }
    public decimal? DiscountPrice { get; set; }

    public string Reference { get; set; }

    public bool Revoked { get; set; }

    public decimal? Price { get; set; }
    public decimal? TaxPrice { get; set; }
    public decimal? TotalNetPrice { get; set; }
    public string UserId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public string Description { get; set; }

    public DateTime? ValidityDate { get; set; }


    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Person Person { get; set; }

    public virtual ICollection<PreInvoiceAddress> PreInvoiceAddresses { get; set; } = new List<PreInvoiceAddress>();

    public virtual ICollection<PreInvoiceFolder> PreInvoiceFolders { get; set; } = new List<PreInvoiceFolder>();

    public virtual AspNetUser User { get; set; }
}
