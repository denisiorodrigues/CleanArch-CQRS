using ClenaArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClenaArch.Infrastructure.EntityConffiguration;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder) 
    {
        builder.ToTable("members");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(m => m.LastName).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Gander).IsRequired().HasMaxLength(10);
        builder.Property(m => m.Email).IsRequired().HasMaxLength(150);
        builder.Property(m => m.IsActive).IsRequired();

        builder.HasData(
            new Member(1, "Jane", "Doe", "feminino", "janis@email.com", true),
            new Member(2, "Jhon", "Doe", "masculino", "jhon@email.com", true)
        );
    }
}
