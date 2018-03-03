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
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext db;
        public BranchRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Branch> GetAll()
        {
            return db.Branchs.ToList();
        }

        public Branch GetId(int id)
        {
            return db.Branchs.Find(id);
        }

        public void Insert(Branch branch)
        {
            db.Branchs.Add(branch);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Branch branch)
        {
            db.Entry(branch).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Branch branch = db.Branchs.Find(id);
            db.Branchs.Remove(branch);
        }
    }
}
