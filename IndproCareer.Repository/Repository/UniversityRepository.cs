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
    public class UniversityRepository : IUniversityRepository
    {
        private readonly ApplicationDbContext db;
        public UniversityRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public University GetId(int id)
        {
            return db.University.Find(id);
        }

        public IEnumerable<University> GetAll()
        {
            return db.University.ToList();
        }

        public void Insert(University university)
        {
            db.University.Add(university);
        }

        public void Update(University university)
        {
            db.Entry(university).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            University university = db.University.Find(id);
            db.University.Remove(university);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public string GetExportData(int id)
        {
            string universityQuery;
            universityQuery = (from Uni in db.University
                                join Col in db.Colleges on Uni.Id equals Col.Id  
                                join Scl in db.Schools  on Col.Id equals Scl.CId
                                join Cls in db.Classes  on  Scl.SId equals Cls.SId
                                where (Uni.Id==id) select Uni.Name).FirstOrDefault();
            return universityQuery;
        }
        //Tuple
    }
}
