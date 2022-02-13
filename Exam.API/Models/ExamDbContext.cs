using Exam.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Models
{
    public class ExamDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {
        }
    }
}
