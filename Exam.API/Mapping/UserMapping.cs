using Exam.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.NationalCode).IsRequired();
        }
    }
}
