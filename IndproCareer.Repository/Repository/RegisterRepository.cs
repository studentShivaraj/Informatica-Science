using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private  ApplicationDbContext db;
        public RegisterRepository(ApplicationDbContext context)
        {
            db = context;
        }
               
        public IEnumerable<Register> GetAllUser()
        {
            return db.Registers.ToList();
        }

        public Register GetById(int id)
        {
            return db.Registers.Find(id);
        }

        public void Insert(Register reg)
        {
            db.Registers.Add(reg);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Register reg)
        {
            db.Entry(reg).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Register branch = db.Registers.Find(id);
            db.Registers.Remove(branch);
        }


        public void FindByNameAsync(string email)
        {
            db.Registers.Where(x => x.Email == email);
        }
        public void GeneratePasswordResetTokenAsync(int userId)
        {            
            db.Registers.Where(x => x.Id == userId);           
        }
    }
}
