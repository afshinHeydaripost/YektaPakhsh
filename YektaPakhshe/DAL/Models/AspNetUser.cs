using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AspNetUser
{
    public string Id { get; set; }

    public string UserName { get; set; }

    public string NormalizedUserName { get; set; }

    public string Email { get; set; }

    public string NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PasswordHash { get; set; }

    public string SecurityStamp { get; set; }

    public string ConcurrencyStamp { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public string Address { get; set; }

    public DateTime? Birthday { get; set; }

    public string LastName { get; set; }

    public string NationalCode { get; set; }

    public string ProfilePicture { get; set; }

    public string FirstName { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<Invoice> InvoiceIntaMediaSenderUsers { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceUsers { get; set; } = new List<Invoice>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<PreInvoice> PreInvoices { get; set; } = new List<PreInvoice>();

    public virtual ICollection<ProductGroup> ProductGroups { get; set; } = new List<ProductGroup>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
    public virtual ICollection<PersonAddress> PersonAddress { get; set; } = new List<PersonAddress>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
