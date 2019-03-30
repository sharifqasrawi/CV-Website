using My_Personal_Website.Models;
using My_Personal_Website.WebsiteLanguages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace My_Personal_Website.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string language = null;
            HttpCookie LanguageCookie = Request.Cookies["culture"];
            if (LanguageCookie != null)
            {
                language = LanguageCookie.Value;
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != "")
                {
                    language = userLang;
                }
                else
                {
                    language = SiteLanguages.GetDefaultLanguage();
                }
            }

            new SiteLanguages().SetLanguage(language);


           
            return base.BeginExecuteCore(callback, state);
        }

        //Changing website language
        public ActionResult ChangeLanguage(string lang)
        {
            new SiteLanguages().SetLanguage(lang);
            

            return Redirect(Request.UrlReferrer.PathAndQuery);
        }


        //public JsonResult GetStyle(string id)
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    SiteStyle style = db.SiteStyles.Find(int.Parse(id));
        //    return Json(style, JsonRequestBehavior.AllowGet);
        //}


        //public JsonResult GetCurrentStyle()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    SiteStyle style = db.SiteStyles.SingleOrDefault(x => x.Active);
        //    return Json(style, JsonRequestBehavior.AllowGet);
        //}  

        [ChildActionOnly]
        protected bool checkFileType(string fileName)
        {
            string fileExtention = Path.GetExtension(fileName);

            switch (fileExtention.ToLower())
            {
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".pdf":
                    return true;
                default:
                    return false;
            }
        }
	}
}