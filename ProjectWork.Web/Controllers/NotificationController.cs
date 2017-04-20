using ProjectWork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectWork.Services;
using System.Threading.Tasks;
using System.Net.Http;

namespace ProjectWork.Web.Controllers
{
    public class NotificationController : Controller
    {
        //MembershipService membershipServiceInstance;

        public NotificationController()
        {
           // membershipServiceInstance=new MembershipService()
        }

        // GET: Notification
        //public ActionResult Index(string email)
        //{
        //    var validationCode = "";
        //    ViewBag.ValidationStatus = false;
        //    var emailValidationStatus = _membershipService.ConfirmEmailAddress(email, validationCode);
        //    if (emailValidationStatus)
        //    {
        //        ViewBag.ValidationStatus = true;
        //    }
        //    else
        //    {
        //        ViewBag.ValidationStatus = false;
        //    }

        //    return View();
        //}
       

          public async Task<ActionResult> Index(string email, string validationCode)
        {
            string apiUrl = String.Format("http://localhost/projectwork/api/Account/GetConfirmation?email={0}&validationCode={1}",email,validationCode);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    ViewBag.emailVerificationstatus = data;
                }else
                {
                    //var data = await response.Content.ReadAsStringAsync();
                    ViewBag.emailVerificationstatus = "false";
                }
            }
            return View();
            
    }
    }
}