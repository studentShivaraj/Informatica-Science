using IndproCareer.Entity.Models;
//using IndproCareer.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
    public interface IContactUsRepository
    {
        IEnumerable<Visiter> GetAll();
        void Send(Visiter contact);
        void Save();
    }
}
