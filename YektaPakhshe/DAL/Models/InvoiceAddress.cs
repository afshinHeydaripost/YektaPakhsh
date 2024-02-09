using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class InvoiceAddress : BaseEntity
{

    public int InvoiceId { get; set; }

    public string PersonReceiverTitle { get; set; }

    public int? PersonStateId { get; set; }

    public string PersonAddress { get; set; }

    public string PersonMobileNumber { get; set; }

    public string PersonPhoneNumber { get; set; }

    public string PersonPostCode { get; set; }

    public virtual Invoice Invoice { get; set; }
}
