using Mc2.CrudTest.Presentation.Server.Core.Domain;

namespace Mc2.CrudTest.Presentation.Server.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.Firstname)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.Lastname)
           .HasMaxLength(200)
           .IsRequired();

        builder.Property(c => c.PhoneNumber)
           .HasMaxLength(20)
           .IsRequired();

        builder.Property(c => c.Email)
           .HasMaxLength(200)
           .IsRequired()
           .IsUnicode();

        builder.Property(c => c.BankAccountNumber)
           .HasMaxLength(200);

        builder.Property(c => c.DateOfBirth)
           .IsRequired();

        builder.HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth })
            .IsUnique();
    }
}

