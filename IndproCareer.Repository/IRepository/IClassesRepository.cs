using IndproCareer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
    public interface IClassesRepository
    {
        IEnumerable<Class> GetAll();
        Class GetId(int id);
        void Insert(Class cls);
        void Save();
        void Update(Class cls);
        void Delete(int id);

    }
}
