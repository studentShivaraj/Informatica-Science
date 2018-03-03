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
    public class ClassesRepository : IClassesRepository
    {
        private ApplicationDbContext db;
        public ClassesRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<Class> GetAll()
        {
            return db.Classes.ToList();
        }

        public Class GetId(int id)
        {
           return db.Classes.Find(id);
        }

        public void Insert(Class cls)
        {
            db.Classes.Add(cls);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Class cls)
        {
            db.Entry(cls).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Class cls = db.Classes.Find(id);
            db.Classes.Remove(cls);
        }
    }
}
