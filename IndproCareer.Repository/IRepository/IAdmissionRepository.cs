using IndproCareer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
    public interface IAdmissionRepository
    {
        IEnumerable<Admission> GetAllAdmission();
        //Admission GetId(int id);
        void Insert(Admission admission);
        void Save();
        //void Update(Admission admission);
        //void Delete(int id);
    }
}
