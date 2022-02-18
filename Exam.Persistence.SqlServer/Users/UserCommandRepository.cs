using Exam.Core.Domain.Users.Contracts;
using Exam.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Exam.Persistence.SqlServer.Users
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly ExamDbContext db;

        public UserCommandRepository(ExamDbContext db)
        {
            this.db = db;
        }

        public async Task<User> UserGetById(int Id) 
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<int> UserAdd(User user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return user.Id;
        }

        public async Task<User> UserUpdate(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return user;
        }
    }

    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly ExamDbContext db;

        public UserQueryRepository(ExamDbContext db)
        {
            this.db = db;
        }

        public async Task<User> UserGetById(int Id)
        {
            return await db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
