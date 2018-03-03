using IndproCareer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
    public interface ICollegeRepository
    {
        IEnumerable<College> GetAll();
        College GetId(int id);
        void Insert(College college);
        void Save();
        void Update(College college);
        void Delete(int id);

    }
}
