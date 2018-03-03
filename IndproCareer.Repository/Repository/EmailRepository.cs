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
    public class EmailRepository : IEmailRepository
    {
         private readonly ApplicationDbContext db;
         public EmailRepository(ApplicationDbContext context)
        {
            db = context;
        }
        
         public IEnumerable<SendMail> GetAll()
         {
             return db.SendMails.ToList();
         }

         public void Send(SendMail sendMail)
         {
             db.SendMails.Add(sendMail);
         }

         public void Save()
         {
             db.SaveChanges();
         }

    }
}
