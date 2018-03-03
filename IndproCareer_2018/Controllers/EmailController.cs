using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
using IndproCareer.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace IndproCareer_2018.Controllers
{
    public class EmailController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        IEmailRepository _emailRepository;
        public EmailController()
        {
            this._emailRepository = new EmailRepository(new ApplicationDbContext());
        }

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "To" : sortOrder;

            IPagedList<SendMail> sendMail = null;

            ApplicationDbContext db = new ApplicationDbContext();
            switch (sortOrder)
            {
                case "To":
                    if (sortOrder.Equals(CurrentSort))
                        sendMail = _emailRepository.GetAll().OrderByDescending(m => m.To).ToPagedList(pageIndex, pageSize);
                    else
                        sendMail = _emailRepository.GetAll().OrderBy(m => m.To).ToPagedList(pageIndex, pageSize);
                    break;

                case "Subject":
                    if (sortOrder.Equals(CurrentSort))
                        sendMail = _emailRepository.GetAll().OrderByDescending(m => m.Subject).ToPagedList(pageIndex, pageSize);
                    else
                        sendMail = _emailRepository.GetAll().OrderBy(m => m.Subject).ToPagedList(pageIndex, pageSize);
                    break;

                case "DateTime":
                    if (sortOrder.Equals(CurrentSort))
                        sendMail = _emailRepository.GetAll().OrderByDescending(m => m.DateTime).ToPagedList(pageIndex, pageSize);
                    else
                        sendMail = _emailRepository.GetAll().OrderBy(m => m.DateTime).ToPagedList(pageIndex, pageSize);
                    break;

                case "Default":
                    sendMail = _emailRepository.GetAll().OrderBy(m => m.To).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(sendMail);
        }

        [HttpPost]
        public ActionResult Index(int? page, string to, DateTime? fromDate = null, DateTime? toDate = null)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            var filter = from mail in _emailRepository.GetAll() select mail;
            if (toDate != null || fromDate != null)
            {
                toDate = toDate.Value.AddDays(1);
                filter = _emailRepository.GetAll().Where(c => c.DateTime >= fromDate.Value && c.DateTime <= toDate);
            }
            if (!string.IsNullOrEmpty(to))
            {
                filter = filter.Where(a => a.To.Contains(to));
            }
            return View(filter.OrderBy(m => m.DateTime).ToPagedList(pageIndex, pageSize));
        }

        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(SendMail sendMail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var senderEmail = new MailAddress("shivaraj.methre@indpro.se", "Shivaraj Mehre");
                    var receiverEmail = new MailAddress(sendMail.To, "Reciever");
                    var password = "DPR@53847";
                    var sub = sendMail.Subject;
                    var body1 = sendMail.To;
                    var body = sendMail.Message;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };

                    using (var mess = new MailMessage(senderEmail, receiverEmail) { Subject = sub, Body = sendMail.Message })
                    {
                        smtp.Send(mess);
                        sendMail.DateTime = DateTime.Now;
                        _emailRepository.Send(sendMail);
                        _emailRepository.Save();
                    }
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Index");

        }

    }
}
