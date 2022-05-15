using MatrimonyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;

namespace MatrimonyAPI.Controllers
{
    public class LoginController : ApiController
    {
        private MatrimonydbEntities db = new MatrimonydbEntities();

        // POST: api/Login
        [HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Login(User user)
        {

          var key = "b14ca5898a4e4133bbce2ea2315a1916";
            var encryptedString = EncryptionDecryption.EncryptString(key, user.PasswordHash);
            //  var decryptstring = EncryptionDecryption.DecryptString(key, reg.PasswordHash);
            int? userId = db.ValidateUser(user.EmailId, encryptedString).FirstOrDefault();
            LoginModel lm  = new  LoginModel();
            switch (userId.Value)
            {
                case -1:
                    lm.UserId = -1;
                    lm.message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    lm.UserId = -2;
                    lm.message = "Account has not been activated.";
                    break;
                default:
                    lm.UserId = Convert.ToInt32(userId);
                    lm.Username = user.EmailId;
                    lm.message = "User Login Succesufully.";
                    break;
            }

            

            return Ok(lm);
        }

        [HttpGet]
        [Route("api/login/GetChangePassword/")]
        // GET: api/GetChange/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetChangePassword(User user)
        {
            var IsExists = IsEmailExists(user.EmailId);

            if(IsExists)
            {
                var GenarateUserVerificationLink = "/Register/UserVerification/";
                var link = "";

                var fromMail = new MailAddress("noreplyreceiptscan@gmail.com", "kolkdpavblcezlun"); // set your email    
                var fromEmailpassword = "*******"; // Set your password     
                var toEmail = new MailAddress(user.EmailId);

                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);
                
                var Message = new MailMessage(fromMail, toEmail);
                Message.Subject = "Registration Completed-Demo";
                Message.Body = "<br/> Your registration completed succesfully." +
                               "<br/> please click on the below link for account verification" +
                               "<br/><br/><a href=" + link + ">" + link + "</a>";
                Message.IsBodyHtml = true;
                smtp.Send(Message);

            }


            return Ok(user);
        }
        public bool IsEmailExists(string eMail)
        {
            var IsCheck = db.Users.Where(email => email.EmailId == eMail).FirstOrDefault();
            return IsCheck != null;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
