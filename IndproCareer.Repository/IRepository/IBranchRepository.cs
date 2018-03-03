using IndproCareer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
    public interface IBranchRepository
    {
        IEnumerable<Branch> GetAll();
        Branch GetId(int id);
        void Insert(Branch branch);
        void Save();
        void Update(Branch branch);
        void Delete(int id);
    }
}
