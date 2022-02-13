using Exam.API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.API.Services.Interfaces
{
    public interface IUserService
    {
        public long CreateUser(CreateUser model);
        public void EditUser(EditUser model);

        public ResponseUser GetByUserId(long id);
    


    }
}
