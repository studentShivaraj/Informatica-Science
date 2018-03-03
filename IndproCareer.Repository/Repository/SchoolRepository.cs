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
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ApplicationDbContext db;
        public SchoolRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<School> GetAll()
        {
            return db.Schools.ToList();
        }

        public School GetId(int id)
        {
            return db.Schools.Find(id);
        }

        public void Insert(School school)
        {
            db.Schools.Add(school);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(School school)
        {
            db.Entry(school).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            School school = db.Schools.Find(id);
            db.Schools.Remove(school);
        }

    }
}
