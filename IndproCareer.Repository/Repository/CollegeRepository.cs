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
    public class CollegeRepository : ICollegeRepository
    {
        private readonly ApplicationDbContext db;
        public CollegeRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<College> GetAll()
        {
           return db.Colleges.ToList();
        }

        public College GetId(int id)
        {
            return db.Colleges.Find(id);
        }

        public void Insert(College college)
        {
            db.Colleges.Add(college);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(College college)
        {
            db.Entry(college).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            College college = db.Colleges.Find(id);
            db.Colleges.Remove(college);
        }
    }
}
