using Exam.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Persistence.SqlServer.TypeConfigurations.Users
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(ExamCommonConfiguration.UserTableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(256);

            builder.Property(x => x.LastName)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(11);

            builder.Property(x => x.NationalCode)
                .HasMaxLength(10);
        }
    }
}
