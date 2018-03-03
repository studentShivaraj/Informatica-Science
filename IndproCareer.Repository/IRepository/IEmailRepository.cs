using IndproCareer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
    public interface IEmailRepository
    {
        IEnumerable<SendMail> GetAll();       
        void Send(SendMail sendMail);
        void Save();

    }
}
