using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
using IndproCareer.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace IndproCareer_2018.Controllers.Api
{
    public class UniversityController : ApiController
    {

        private IUniversityRepository _universityRepository;
        public UniversityController()
        {
            this._universityRepository = new UniversityRepository(new ApplicationDbContext());
        }


        //public string GetId(int id)
        //{
        //    var test = _universityRepository.GetId(id);
        //    return test.ToString();


        //}

        //public JsonResult GetSchool(int id)
        //{
        //    var school = _universityRepository.GetId(id);
        //    return json(school,JsonRequestBehavior.AllowGet);
        //}

    }
}
