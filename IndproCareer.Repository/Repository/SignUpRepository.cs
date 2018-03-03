using IndproCareer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndproCareer.Entity;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using IndproCareer.Repository.DbContext;
using IndproCareer.Entity.Models;

namespace IndproCareer.Repository.Repository
{
    public class SignUpRepository : ISignUpRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //public void Insert(SignUp signUp)
        //{
        //    db.SignUps.Add(signUp);
        //}

        //public async Task<bool> Save(SignUp signUp)
        //{
        //    try
        //    {
        //        db.SignUps.Add(signUp);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<bool> Update(SignUp signUp)
        //{
        //    try
        //    {
        //        if (signUp.Id == 0)
        //            db.Entry(signUp).State = EntityState.Modified;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



    }
}
