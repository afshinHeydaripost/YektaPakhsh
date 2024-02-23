using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PersonAddress : BaseEntity
{

    public int PersonId { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }
    public string MobileNumber { get; set; }
    public string PhoneNumber { get; set; }
    public int? StateId { get; set; }
    public int? CityId { get; set; }

    public string UserId { get; set; }
    public bool IsActive { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }
    public virtual Person Person { get; set; }
    public virtual AspNetUser User { get; set; }
    public virtual ICollection<PreInvoiceAddress> PreInvoiceAddresses { get; set; } = new List<PreInvoiceAddress>();

}
