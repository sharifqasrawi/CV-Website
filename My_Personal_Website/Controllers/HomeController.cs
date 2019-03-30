using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_Personal_Website.Models;
using My_Personal_Website.WebsiteLanguages;
namespace My_Personal_Website.Controllers
{
    public class HomeController : BaseController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
           

            CVPersonalModel p = db.CVPersonalInfo.FirstOrDefault();
            List<CVEduModel> eds = db.CVEducation.Include("Projects").OrderByDescending(x => x.DateFinish).ToList();
            List<CVProfModel> profs = db.Profs.Include("Refs").OrderByDescending(x => x.FinishDate).ToList();
            List<CVLangModel> langs = db.Languages.ToList();
            List<CVTrainingModel> trns = db.Trainings.OrderByDescending(x => x.CourceDate).ToList();
            List<CVSkillsModel> skls = db.Skills.OrderBy(x => x.SkillType).ToList();

            HomeModel h = new HomeModel
            {
                Personal = p,
                Educations = eds,
                Profs = profs,
                Languages = langs,
                Trainings = trns,
                Skills = skls
            };

            switch(SiteLanguages.GetCurrentLanguageCulture())
            {
                case "en-US":
                    ViewBag.type = new SelectList(skls.OrderBy(x => x.SkillType).Select(x => x.SkillType).Distinct().ToList());
                    break;
                case "fr-FR":
                    ViewBag.type = new SelectList(skls.OrderBy(x => x.SkillType_Fr).Select(x => x.SkillType_Fr).Distinct().ToList());
                    break;
                default:
                    ViewBag.type = new SelectList(skls.OrderBy(x => x.SkillType).Select(x => x.SkillType).Distinct().ToList());
                    break;
            }

            return View(h);
        }

        public PartialViewResult Skills(string type)
        {
            CVPersonalModel p = db.CVPersonalInfo.FirstOrDefault();
            List<CVEduModel> eds = db.CVEducation.Include("Projects").ToList();
            List<CVProfModel> profs = db.Profs.Include("Refs").ToList();
            List<CVLangModel> langs = db.Languages.ToList();
            List<CVTrainingModel> trns = db.Trainings.ToList();
            List<CVSkillsModel> skls = null;

            switch (SiteLanguages.GetCurrentLanguageCulture())
            {
                case "en-US":
                    skls = db.Skills.Where(x => x.SkillType == type || string.IsNullOrEmpty(type)).OrderBy(x => x.SkillType).ToList();
                    break;
                case "fr-FR":
                    skls = db.Skills.Where(x => x.SkillType_Fr == type || string.IsNullOrEmpty(type)).OrderBy(x => x.SkillType_Fr).ToList();
                    break;
                default:
                    skls = db.Skills.Where(x => x.SkillType == type || string.IsNullOrEmpty(type)).OrderBy(x => x.SkillType).ToList();
                    break;
            }

            HomeModel h = new HomeModel
            {
                Personal = p,
                Educations = eds,
                Profs = profs,
                Languages = langs,
                Trainings = trns,
                Skills = skls
            };

            return PartialView("_CVSkills",h);
         //   return skls.First().SkillType.ToString();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ContactModel c = new ContactModel();
            c.Address = db.Address.OrderByDescending(x => x.Id).FirstOrDefault();
            c.Social = db.Social.FirstOrDefault();
            return View(c);
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            MessageModel msg = new MessageModel()
            {
                Email = model.Message.Email,
                Subject = model.Message.Subject,
                Msg = model.Message.Msg,
                DT = DateTime.Now
            };

            try
            {
                db.Messages.Add(msg);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            catch
            {

            }

            return View(msg);
        }
    }
}