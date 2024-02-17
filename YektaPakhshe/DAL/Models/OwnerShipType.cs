using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OwnerShipType : BaseEntity
{
    public string Title { get; set; }
    public string Code { get; set; }
    public virtual ICollection<Person> Person { get; set; } = new List<Person>();
}
