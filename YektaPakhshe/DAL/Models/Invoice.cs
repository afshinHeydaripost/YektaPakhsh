using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Invoice : BaseEntity
{
    public string InvoiceNo { get; set; }

    public DateTime InvoiceDate { get; set; }

    public int? PreInvoiceId { get; set; }

    public int PersonId { get; set; }

    public decimal? DiscountRate { get; set; }

    public string Reference { get; set; }

    public bool Revoked { get; set; }

    public string UserId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public string Description { get; set; }

    public int? TaxInvoiceTypeId { get; set; }

    public int? TaxInvoiceTemplateTypeId { get; set; }

    public int? TaxInvoiceSubjectTypeId { get; set; }

    public int? TaxCheckoutTypeId { get; set; }

    public string TaxId { get; set; }

    public string TaxReferenceNumber { get; set; }

    public string TaxErrorCode { get; set; }

    public string TaxErrorDetail { get; set; }

    public DateTime? SendToIntaMediaDateTime { get; set; }

    public string Uid { get; set; }

    public string Status { get; set; }

    public string IntaMediaSenderUserId { get; set; }

    public virtual AspNetUser IntaMediaSenderUser { get; set; }

    public virtual ICollection<InvoiceAddress> InvoiceAddresses { get; set; } = new List<InvoiceAddress>();

    public virtual ICollection<InvoiceFolder> InvoiceFolders { get; set; } = new List<InvoiceFolder>();

    public virtual Person Person { get; set; }

    public virtual PreInvoice PreInvoice { get; set; }

    public virtual AspNetUser User { get; set; }
}
