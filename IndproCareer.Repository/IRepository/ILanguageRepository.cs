using IndproCareer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndproCareer.Repository.IRepository
{
   public interface ILanguageRepository
    {
       IEnumerable<Language> GetAll();

       Language GetId(int id);
       void Insert(Language language);
       void Update(Language language);
       void Delete(int id);
       void Save();
    }
}
