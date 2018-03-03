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
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ApplicationDbContext db;
        public LanguageRepository(ApplicationDbContext context)
        {
            db = context;
        }
       
        public IEnumerable<Language> GetAll()
        {
            return db.Languages.ToList();
        }

        public Language GetId(int id)
        {
            return db.Languages.Find(id);
        }

        public void Insert(Language language)
        {
            db.Languages.Add(language);
        }

        public void Update(Language language)
        {
            db.Entry(language).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Language language = db.Languages.Find(id);
            db.Languages.Remove(language);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
