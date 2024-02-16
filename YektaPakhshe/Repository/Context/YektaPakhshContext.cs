using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context;

public partial class YektaPakhshContext : DbContext
{
    public YektaPakhshContext()
    {
    }

    public YektaPakhshContext(DbContextOptions<YektaPakhshContext> options)
        : base(options)
    {
    }

	public virtual DbSet<UserAccessProduct> UserAccessProducts { get; set; }
	public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceAddress> InvoiceAddresses { get; set; }

    public virtual DbSet<InvoiceFolder> InvoiceFolders { get; set; }

    public virtual DbSet<Person> Person { get; set; }

    public virtual DbSet<PreInvoice> PreInvoices { get; set; }

    public virtual DbSet<PreInvoiceAddress> PreInvoiceAddresses { get; set; }

    public virtual DbSet<PreInvoiceFolder> PreInvoiceFolders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductGroup> ProductGroups { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.RoleId).IsRequired();

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Address).HasMaxLength(2000);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName)
                .HasMaxLength(250)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.NationalCode).HasMaxLength(20);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.ProfilePicture).HasMaxLength(2000);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoice");

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(3000);
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.IntaMediaSenderUserId).HasMaxLength(450);
            entity.Property(e => e.InvoiceDate).HasColumnType("date");
            entity.Property(e => e.InvoiceNo)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.PreInvoiceId).HasColumnName("preInvoiceId");
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.SendToIntaMediaDateTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(150);
            entity.Property(e => e.TaxErrorCode).HasMaxLength(500);
            entity.Property(e => e.TaxErrorDetail).HasMaxLength(500);
            entity.Property(e => e.TaxId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TaxReferenceNumber).HasMaxLength(500);
            entity.Property(e => e.Uid)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);

            entity.HasOne(d => d.IntaMediaSenderUser).WithMany(p => p.InvoiceIntaMediaSenderUsers)
                .HasForeignKey(d => d.IntaMediaSenderUserId)
                .HasConstraintName("FK_Invoice_AspNetUsers1");

            entity.HasOne(d => d.Person).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Person");

            entity.HasOne(d => d.PreInvoice).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PreInvoiceId)
                .HasConstraintName("FK_Invoice_perInvoice");

            entity.HasOne(d => d.User).WithMany(p => p.InvoiceUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_AspNetUsers");
        });

        modelBuilder.Entity<InvoiceAddress>(entity =>
        {
            entity.ToTable("InvoiceAddress");

            entity.Property(e => e.PersonAddress).HasMaxLength(1000);
            entity.Property(e => e.PersonMobileNumber).HasMaxLength(200);
            entity.Property(e => e.PersonPhoneNumber).HasMaxLength(200);
            entity.Property(e => e.PersonPostCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PersonReceiverTitle).HasMaxLength(200);

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceAddresses)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceAddress_Invoice");
        });

        modelBuilder.Entity<InvoiceFolder>(entity =>
        {
            entity.ToTable("InvoiceFolder");

            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Reference).HasMaxLength(150);
            entity.Property(e => e.TaxPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TaxTollPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TotalNetPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.UnitQuantity).HasColumnType("decimal(38, 3)");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceFolders)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceFolder_Invoice");

            entity.HasOne(d => d.Product).WithMany(p => p.InvoiceFolders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceFolder_Product");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.BirthDate).HasMaxLength(10);
            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.EconomicCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.NationalityCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Reference).HasMaxLength(100);
            entity.Property(e => e.RegisterationCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.People)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_AspNetUsers");
        });

        modelBuilder.Entity<PreInvoice>(entity =>
        {
            entity.ToTable("preInvoice");

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(3000);
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.PreInvoiceDate)
                .HasColumnType("date")
                .HasColumnName("preInvoiceDate");
            entity.Property(e => e.PreInvoiceNo)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("preInvoiceNo");
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);
            entity.Property(e => e.ValidityDate).HasColumnType("date");

            entity.HasOne(d => d.Invoice).WithMany(p => p.PreInvoices)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_preInvoice_Invoice");

            entity.HasOne(d => d.Person).WithMany(p => p.PreInvoices)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_preInvoice_Person");

            entity.HasOne(d => d.User).WithMany(p => p.PreInvoices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_preInvoice_AspNetUsers");
        });

        modelBuilder.Entity<PreInvoiceAddress>(entity =>
        {
            entity.ToTable("preInvoiceAddress");

            entity.Property(e => e.PersonAddress).HasMaxLength(1000);
            entity.Property(e => e.PersonMobileNumber).HasMaxLength(200);
            entity.Property(e => e.PersonPhoneNumber).HasMaxLength(200);
            entity.Property(e => e.PersonPostCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PersonReceiverTitle).HasMaxLength(200);
            entity.Property(e => e.PreInvoiceId).HasColumnName("preInvoiceId");

            entity.HasOne(d => d.PreInvoice).WithMany(p => p.PreInvoiceAddresses)
                .HasForeignKey(d => d.PreInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_preInvoiceAddress_preInvoice");
        });

        modelBuilder.Entity<PreInvoiceFolder>(entity =>
        {
            entity.ToTable("preInvoiceFolder");

            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.PreInvoiceId).HasColumnName("preInvoiceId");
            entity.Property(e => e.Quantity).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.Reference).HasMaxLength(150);
            entity.Property(e => e.TaxPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TaxTollPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TotalNetPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.UnitQuantity).HasColumnType("decimal(38, 3)");

            entity.HasOne(d => d.PreInvoice).WithMany(p => p.PreInvoiceFolders)
                .HasForeignKey(d => d.PreInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_preInvoiceFolder_preInvoice");

            entity.HasOne(d => d.Product).WithMany(p => p.PreInvoiceFolders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_preInvoiceFolder_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.PictureImg).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(300);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);

            entity.HasOne(d => d.ProductGroup).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductGroupId)
                .HasConstraintName("FK_Product_ProductGroup");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_AspNetUsers");
        });

        modelBuilder.Entity<ProductGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GoodsGroup");

            entity.ToTable("ProductGroup");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.ProductGroups)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GoodsGroup_AspNetUsers");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.TaxReferenceId).HasMaxLength(500);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.Units)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Unit_AspNetUsers");
        });

		modelBuilder.Entity<UserAccessProduct>(entity =>
		{
			entity.ToTable("UserAccessProduct");

			entity.Property(e => e.UserId)
				.IsRequired()
				.HasMaxLength(450);
		});
		OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
