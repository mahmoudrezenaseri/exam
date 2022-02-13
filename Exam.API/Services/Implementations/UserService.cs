using Exam.API.Models;
using Exam.API.Models.DTOs;
using Exam.API.Models.Entities;
using Exam.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ExamDbContext _context;

        public UserService(ExamDbContext context)
        {
            _context = context;
        }
        public long CreateUser(CreateUser model)
        {
            var user = User.Create(firstName: model.FirstName, lastName: model.LastName, phoneNumber: model.PhoneNumber, nationalCode: model.NationalCode);
            _context.Add(user);
             _context.SaveChanges();

            return user.Id;
        }

        public void EditUser(EditUser model)
        {
            var user = _context.Users.Where(q => q.Id == model.Id).FirstOrDefault();

            user.Edit(firstName: model.FirstName, lastName: model.LastName, phoneNumber: model.PhoneNumber, nationalCode: model.NationalCode);

            _context.SaveChanges();
        }

      

        public ResponseUser GetByUserId(long id)
        {
            var user = _context.Users.Where(q => q.Id == id).FirstOrDefault();
            ResponseUser userModel = new ResponseUser(id: user.Id, firstName: user.FirstName, lastName: user.LastName, phoneNumber: user.PhoneNumber, nationalCode: user.NationalCode);
            return userModel;
        }
    }
}
