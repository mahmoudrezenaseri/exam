using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).ValueGeneratedNever()
            .HasConversion(a => a.DbId,
                guid => new UserId(guid));

        builder.Property(a => a.NationalCode)
            .HasConversion(a=>a.Value,value=>
                new NationalCode(value))
            .HasMaxLength(10).IsRequired();


        builder.Property(a => a.PhoneNumber).HasMaxLength(11).IsRequired();
    }
}