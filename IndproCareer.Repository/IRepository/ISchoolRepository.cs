using IndproCareer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
   public interface ISchoolRepository
    {
       IEnumerable<School> GetAll();
       School GetId(int id);
       void Insert(School school);
       void Save();
       void Update(School school);
       void Delete(int id);

    }
}
