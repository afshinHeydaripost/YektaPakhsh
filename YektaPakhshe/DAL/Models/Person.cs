using DAL.Base;
using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Person : BaseEntity
{

	public int PersonId { get; set; }
	public string Code { get; set; }
	public string Title { get; set; }

	public string EconomicCode { get; set; }
	public string BirthDate { get; set; }
	public string NationalityCode { get; set; }
	public string RegisterationCode { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }

	public int OwnerShipTypeId { get; set; }
	public int? LegalTypeId { get; set; }

	public string Description { get; set; }
	public string Reference { get; set; }
	public bool Disabled { get; set; }
}
