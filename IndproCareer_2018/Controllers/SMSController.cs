using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.AspNet.Mvc;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using IndproCareer.Entity.Models;
using Twilio.AspNet.Common;
using System.Net;
using System.IO;

namespace IndproCareer_2018.Controllers
{
    public class SMSController : TwilioController
    {

        [HttpGet]
        public ActionResult SendSms()
        {
            return View();
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult SendSms(SendSMS sms)
        //{
        //    try
        //    {
        //        // Find your Account Sid and Auth Token at twilio.com/console
        //        const string accountSid = "AC7833fa4294c077ba494b99b5a5e64eb7";
        //        const string authToken = "67eec6dfb009ad2210f74936bcbf5452";
        //        TwilioClient.Init(accountSid, authToken);

        //        var to = new PhoneNumber("+919620432531");
        //        var message = MessageResource.Create(
        //            to,
        //            from: new PhoneNumber("+14697317148"),
        //            body: "This is the ship that made the Kessel Run in fourteen parsecs?");
        //        //return Content(message.Sid);
        //        Console.WriteLine(message.Sid);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return View(sms);
        //}

        //public ActionResult RecieveSms()
        //{
        //    var response = new MessagingResponse();
        //    response.Message("the robot is coming");
        //    return TwiML(response);
        //}

        public TwiMLResult Index(SmsRequest request)
        {
            var response = new MessagingResponse();
            response.Message("Hello World");
            return TwiML(response);
        }


        public ActionResult SendSms(SmsRequest sms)
        {

            // Find your Account Sid and Auth Token at twilio.com/console
            var accountSid = "AC7833fa4294c077ba494b99b5a5e64eb7";
            var authToken = "67eec6dfb009ad2210f74936bcbf5452";
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber("+919620432531");
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("+14697317148"),
                body: "This is the ship that made the Kessel Run in fourteen parsecs?");
            //return Content(message.Sid, sms);
            // Console.WriteLine(message.Sid);
            return Content(message.Sid);
        }

        [HttpGet]
        public ActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Send(SendSMS sms)
        {
            WebClient client = new WebClient();
            //Stream s = client.OpenRead(string.Format("https://platform.clickatell.com/messages/http/send?apiKey=InS1ggfLSQm16xet4WVLnQ==&to{0}=&content={1}", sms.To, sms.Body));
            Stream s = client.OpenRead(string.Format("https://platform.clickatell.com/messages/http/send?apiKey=-8poEXXZR9iM4l3nSopj_A==&to=919620432531&content=hiiiii"));


            StreamReader reader = new StreamReader(s);
            string result = reader.ReadToEnd();
            ViewBag.Message = result;
            return View();
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(SendSMS sms1)
        {
            WebClient client = new WebClient();           
            Stream data = client.OpenRead(string.Format("https://platform.clickatell.com/messages/http/send?apiKey=-8poEXXZR9iM4l3nSopj_A==&to={0}&content={1}",sms1.To,sms1.Body));

            StreamReader reader = new StreamReader(data);
            string result = reader.ReadToEnd();
            //var to = sms1.To;
            //var Body = sms1.Body;
            ViewBag.Result = result;
            return View(sms1);
        }
    }
}
