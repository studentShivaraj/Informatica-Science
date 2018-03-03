using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
//using IndproCareer.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
         private readonly ApplicationDbContext db;
         public ContactUsRepository(ApplicationDbContext context)
        {
            db = context;
        }

         public IEnumerable<Visiter> GetAll()
         {
             return db.Visiters.ToList();
         }

         public void Send(Visiter contact)
         {
             db.Visiters.Add(contact);
         }

         public void Save()
         {
             db.SaveChanges();
         }
    }
}
