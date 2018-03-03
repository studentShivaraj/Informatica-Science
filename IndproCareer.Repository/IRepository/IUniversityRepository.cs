using IndproCareer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
    public interface IUniversityRepository
    {
        University GetId(int id);
        IEnumerable<University> GetAll();
        void Insert(University university);
        void Update(University university);
        void Delete(int id);
        void Save();

        string GetExportData(int id);
    }
}
