using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
using IndproCareer.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;

namespace IndproCareer_2018.Controllers
{
    public class ContactUsController : Controller
    {
        IContactUsRepository _contactUsRepository;
        public ContactUsController()
        {
            this._contactUsRepository = new ContactUsRepository(new ApplicationDbContext());
        }

        public ActionResult Index()
        {
            return View(_contactUsRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Visiter contact)
        {
            try
            {
                System.Net.Mail.MailMessage mailService = new System.Net.Mail.MailMessage();
                mailService.From = new MailAddress(contact.Email);
                mailService.To.Add("shivarajkm1991@gmail.com");// Change this where you want to receice the mail
                mailService.Subject = contact.FirstName;
                mailService.Body = contact.Comments + "<br/><br/>" + contact.FirstName + " <br/>" + contact.LastName + "<br/> +" + contact.Phone;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                //Email address using which mail will send
                smtp.Credentials = new System.Net.NetworkCredential("shivaraj.methre@indpro.se", "DPR@53847");

                smtp.EnableSsl = true;
                smtp.Send(mailService);
                contact.DateTime = DateTime.Now;
                _contactUsRepository.Send(contact);
                _contactUsRepository.Save();               
                ViewBag.Message = "Thank you for Contacting us ";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.Clear();
                ViewBag.Message = " Soory we are facing Problem here {ex.Message}";
            }
            return View();

        }

    }
}
