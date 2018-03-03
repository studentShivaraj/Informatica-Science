using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.Repository
{
    public class UserRepository
    {

        private readonly ApplicationDbContext db;
        public UserRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public void FindByNameAsync(string email)
        {
            db.Registers.Where(x => x.Email == email);
        }
    }
}
