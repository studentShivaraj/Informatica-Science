using IndproCareer.Entity.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
    public interface IRegisterRepository
    {
        IEnumerable<Register> GetAllUser();
        Register GetById(int id);
        void Insert(Register register);
        void Save();
        void Update(Register register);
        void Delete(int id);

        void FindByNameAsync(string email);

        void GeneratePasswordResetTokenAsync(int userId);
    }
}

