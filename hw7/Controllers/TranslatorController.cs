using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hw7.Models;

namespace hw7.Controllers
{
    public class TranslatorController : Controller
    {
        private RequestLogModel db = new RequestLogModel(); 

        // GET: Translator
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Sticker(string userInput)
        {

            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["ApiKey"];
            string apiURL = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + userInput;
            Debug.WriteLine(apiURL);
            Console.WriteLine(apiURL);
            
            WebRequest apiRequest = WebRequest.Create(apiURL);
            WebResponse getResponse = apiRequest.GetResponse();

            Stream data = apiRequest.GetResponse().GetResponseStream();

            string conStr = new StreamReader(data).ReadToEnd();

            //string convString = apiURL;

            var serialize = new System.Web.Script.Serialization.JavaScriptSerializer();
            var jsonObj = serialize.DeserializeObject(conStr);

            //DB Works
            var dbCon = db.RLModel.Create();
            dbCon.TimeNow = DateTime.Now;
            dbCon.Request = userInput;
            dbCon.IP = Request.UserHostAddress;
            dbCon.BrowserType = Request.UserAgent;
            db.RLModel.Add(dbCon);
            db.SaveChanges();

            data.Close();
            getResponse.Close();

            return Json(jsonObj, JsonRequestBehavior.AllowGet);
        }

    }
}