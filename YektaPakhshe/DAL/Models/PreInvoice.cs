using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PreInvoice : BaseEntity
{
    public string PreInvoiceNo { get; set; } = null!;

    public DateTime PreInvoiceDate { get; set; }
}
