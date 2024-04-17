using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PK_EF.Extentions;


namespace PumpkinPatchApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /*public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();


        }*/
        public ActionResult Contact(ContactModels c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    MailAddress from = new MailAddress(c.Email.ToString());

                    // Set up your email details (sender and recipient addresses)
                    msg.From = new MailAddress("sender@gmail.com");
                    msg.To.Add("evabalkarli@gmail.com");
                    msg.Subject = "Contact Us";

                    // Configure SMTP settings (e.g., credentials, port, SSL)
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("sender@gmail.com", "email password");
                    smtp.Port = 587;

                    // Construct the email body
                    StringBuilder sb = new StringBuilder();
                    sb.Append("First name: " + c.Name);
                    sb.Append(Environment.NewLine);
                   
                 
                    sb.Append("Email: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Comments: " + c.Comment);
                    msg.Body = sb.ToString();

                    // Send the email
                    smtp.Send(msg);
                    msg.Dispose();

                    return View("Success"); // Display a success view
                }
                catch (Exception)
                {
                    return View("Error"); // Display an error view
                }
            }

            return View(); // Display the initial contact form view
        }
    }
}