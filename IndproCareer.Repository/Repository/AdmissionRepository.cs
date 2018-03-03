using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
//using IndproCareer.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndproCareer.Entity.Models;

namespace IndproCareer.Repository.Repository
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly ApplicationDbContext db;
        public AdmissionRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Admission> GetAllAdmission()
        {
            return db.Admissions.ToList();
        }

        public void Insert(Admission admission)
        {
            db.Admissions.Add(admission);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
