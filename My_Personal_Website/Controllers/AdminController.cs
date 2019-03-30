using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_Personal_Website.Models;
using System.IO;
namespace My_Personal_Website.Controllers
{
   [Authorize]
    public class AdminController : BaseController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Admin/
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Personal()
        {
            CVPersonalModel p = db.CVPersonalInfo.FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Personal(CVPersonalModel model, HttpPostedFileBase[] uploadFile,HttpPostedFileBase uploadFile2)
        {
            CVPersonalModel p = db.CVPersonalInfo.FirstOrDefault();
            try
            {
                string imgPath = "";
                string imgFileName = "";

                string CvPath = "";
                string CvFileName = "";

                //Saving uploaded image
                if (uploadFile[0] != null && uploadFile[0].ContentLength > 0)
                {
                    if (checkFileType(uploadFile[0].FileName))
                    {
                        imgFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + Path.GetFileName(uploadFile[0].FileName);
                        imgPath = "~/Uploads/" + imgFileName;
                        uploadFile[0].SaveAs(Server.MapPath(imgPath));
                    }
                    else
                    {
                        imgPath = p.ImagePath;
                    }
                }

                if (uploadFile2 != null && uploadFile2.ContentLength > 0)
                {
                    if (checkFileType(uploadFile2.FileName))
                    {
                        CvFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + Path.GetFileName(uploadFile2.FileName);
                        CvPath = "~/Uploads/" + CvFileName;
                        uploadFile2.SaveAs(Server.MapPath(CvPath));
                    }
                    else
                    {
                        CvPath = p.CVPath;
                    }
                }

                

                p.Name = model.Name;
                p.Desc = model.Desc;
                p.Desc_Fr = model.Desc_Fr;
                p.BirthDate = Convert.ToDateTime(model.BirthDate);
                p.Email = model.Email;
                p.Telephone = model.Telephone;
                p.ImagePath = imgPath;
                p.CVPath = CvPath;

                db.SaveChanges();
                return RedirectToAction("Index", "admin");


            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult UploadCV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadCV(HttpPostedFileBase[] uploadFile)
        {
            CVPersonalModel p = db.CVPersonalInfo.FirstOrDefault();
            try
            {
           
                string CvPath = "";
                string CvFileName = "";

                //Saving uploaded image
                if (uploadFile[0] != null && uploadFile[0].ContentLength > 0)
                {
                    if (checkFileType(uploadFile[0].FileName))
                    {
                        CvFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + Path.GetFileName(uploadFile[0].FileName);
                        CvPath = "~/Uploads/" + CvFileName;
                        uploadFile[0].SaveAs(Server.MapPath(CvPath));
                    }
                    else
                    {
                        CvPath = p.CVPath;
                    }
                }

                p.CVPath = CvPath;
                db.SaveChanges();

                return RedirectToAction("Personal", "Admin");
            }
            catch
            {

            }
            return View();
        }


        public ActionResult Education()
        {
            List<CVEduModel> e = db.CVEducation.Include("Projects").OrderByDescending(x => x.DateFinish).ToList();

            return View(e);
        }

        public ActionResult AddEdu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEdu(CVEduModel model, HttpPostedFileBase uploadFile)
        {
            try
            {

                string path = "";
                string fileName = "";

                //Saving uploaded image
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    if (checkFileType(uploadFile.FileName))
                    {
                        fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + Path.GetFileName(uploadFile.FileName);
                        path = "~/Uploads/" + fileName;
                        uploadFile.SaveAs(Server.MapPath(path));
                    }
                    else
                    {
                        path = " ";
                    }
                }



                CVEduModel e = new CVEduModel()
                {
                    Degree = model.Degree,
                    Degree_Fr = model.Degree_Fr,
                    Major = model.Major,
                    Major_Fr = model.Major_Fr,
                    University = model.University,
                    University_Fr = model.University_Fr,
                    UniversityWebsite = model.UniversityWebsite,
                    Country = model.Country,
                    Country_Fr = model.Country_Fr,
                    City = model.City,
                    City_Fr = model.City_Fr,
                    DateStart = model.DateStart,
                    DateFinish = model.DateFinish,
                    Score = model.Score,
                    ImgPath = path
                };

                db.CVEducation.Add(e);
                db.SaveChanges();
                return RedirectToAction("Education");
            }
            catch
            {

            }

            return View(model);
        }

        public ActionResult EditEdu(int id)
        {
            try
            {
                CVEduModel e = db.CVEducation.Find(id);
                return View(e);
            }
            catch
            {

            }
            return RedirectToAction("Education");
        }

        [HttpPost]
        public ActionResult EditEdu(CVEduModel model, HttpPostedFileBase uploadFile)
        {
            try
            {
                CVEduModel e = db.CVEducation.Find(model.Id);
                string path = e.ImgPath;
                string fileName = "";

                //Saving uploaded image
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    if (checkFileType(uploadFile.FileName))
                    {
                        fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + Path.GetFileName(uploadFile.FileName);
                        path = "~/Uploads/" + fileName;
                        uploadFile.SaveAs(Server.MapPath(path));
                    }
                    else
                    {
                        path = e.ImgPath;
                    }
                }
                


               
                e.Degree = model.Degree;
                e.Degree_Fr = model.Degree_Fr;
                e.Major = model.Major;
                e.Major_Fr = model.Major_Fr;
                e.University = model.University;
                e.University_Fr = model.University_Fr;
                e.UniversityWebsite = model.UniversityWebsite;
                e.Country = model.Country;
                e.Country_Fr = model.Country_Fr;
                e.City = model.City;
                e.City_Fr = model.City_Fr;
                e.DateStart = model.DateStart;
                e.DateFinish = model.DateFinish;
                e.Score = model.Score;
                e.ImgPath = path;

                db.SaveChanges();
                return RedirectToAction("Education");
            }
            catch
            {

            }
            return RedirectToAction("Education");
        }

        public ActionResult AddProject()
        {
           
            return View();
        }


        [HttpPost]
        public ActionResult AddProject(EduProject model,string EduId)
        {
            try
            {


                EduProject p = new EduProject()
                {
                    ProjectName = model.ProjectName,
                    ProjectDesc = model.ProjectDesc,
                    ProjectName_Fr = model.ProjectName_Fr,
                    ProjectDesc_Fr = model.ProjectDesc_Fr,
                    ProjectLink = model.ProjectLink,
                    Score = model.Score,
                    Edu = db.CVEducation.Find(int.Parse(EduId))
                };

                db.EduProjects.Add(p);
                db.SaveChanges();

                return RedirectToAction("Education");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult EditProject(int id)
        {
            EduProject p = db.EduProjects.Include("Edu").SingleOrDefault(x => x.Id == id);
            return View(p);
        }

        [HttpPost]
        public ActionResult EditProject(EduProject model, string EduId)
        {
            try
            {
                EduProject p = db.EduProjects.Include("Edu").SingleOrDefault(x => x.Id == model.Id);
                p.ProjectName = model.ProjectName;
                p.ProjectName_Fr = model.ProjectName_Fr;
                p.ProjectDesc = model.ProjectDesc;
                p.ProjectDesc_Fr = model.ProjectDesc_Fr;
                p.ProjectLink = model.ProjectLink;
                p.Score = model.Score;
                p.Edu.Id = int.Parse(EduId);

                db.SaveChanges();
                return RedirectToAction("Education");
            }
            catch
            {

            }
            return View(model);
        }
       

        public ActionResult DeleteProject(int id)
        {
            try
            {
                EduProject p = db.EduProjects.Find(id);
                db.EduProjects.Remove(p);
                db.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("Education");
        }

        public ActionResult DeleteEdu(int id)
        {
            List<CVEduModel> e = db.CVEducation.Include("Projects").OrderByDescending(x => x.DateFinish).ToList();

            try
            {
                CVEduModel etd = db.CVEducation.Find(id);
                if(etd.Projects.Count > 0)
                {
                    for (int i = 0; i < etd.Projects.Count; i++)
                    {
                        List<EduProject> ps = db.EduProjects.Where(x => x.Edu.Id == id).ToList();
                        foreach(EduProject p in ps)
                        {
                            db.EduProjects.Remove(p);
                        }
                        db.SaveChanges();
                    }
                }
                db.CVEducation.Remove(etd);
                db.SaveChanges();

                return RedirectToAction("Education", e);
            }
            catch
            {

            }

            return RedirectToAction("Education", e);
        }

        public ActionResult Experiences()
        {
            List<CVProfModel> e = db.Profs.Include("Refs").OrderByDescending(x => x.FinishDate).ToList();
            return View(e);
        }

        public ActionResult AddExp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddExp(CVProfModel model, HttpPostedFileBase uploadFile)
        {
            try
            {
                string path = "";
                string fileName = "";

                //Saving uploaded image
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    if (checkFileType(uploadFile.FileName))
                    {
                        fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + Path.GetFileName(uploadFile.FileName);
                        path = "~/Uploads/" + fileName;
                        uploadFile.SaveAs(Server.MapPath(path));
                    }
                   
                }

                CVProfModel e = new CVProfModel()
                {
                    Position = model.Position,
                    Position_Fr = model.Position_Fr,
                    Company = model.Company,
                    Company_Fr = model.Company_Fr,
                    CompanyWebsite = model.CompanyWebsite,
                    Country = model.Country,
                    Country_Fr = model.Country_Fr,
                    City = model.City,
                    City_Fr = model.City_Fr,
                    Desc_Fr = model.Desc_Fr,
                    Desc = model.Desc,
                    DateStart = Convert.ToDateTime(model.DateStart),
                    FinishDate = Convert.ToDateTime(model.FinishDate),
                    ImgPath = path
                };

                db.Profs.Add(e);
                db.SaveChanges();

                return RedirectToAction("Experiences");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult EditExp(int id)
        {
            CVProfModel e = db.Profs.Find(id);
            return View(e);
        }

        [HttpPost]
        public ActionResult EditExp(CVProfModel model, HttpPostedFileBase uploadFile)
        {
            try
            {
                CVProfModel e = db.Profs.Find(model.Id);
                string path = e.ImgPath;
                string fileName = "";

                //Saving uploaded image
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    if (checkFileType(uploadFile.FileName))
                    {
                        fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + Path.GetFileName(uploadFile.FileName);
                        path = "~/Uploads/" + fileName;
                        uploadFile.SaveAs(Server.MapPath(path));
                    }

                }


                e.Position = model.Position;
                e.Position_Fr = model.Position_Fr;
                e.Company = model.Company;
                e.Company_Fr = model.Company_Fr;
                e.CompanyWebsite = model.CompanyWebsite;
                e.Country = model.Country;
                e.Country_Fr = model.Country_Fr;
                e.City = model.City;
                e.City_Fr = model.City_Fr;
                e.Desc = model.Desc;
                e.Desc_Fr = model.Desc_Fr;
                e.DateStart = Convert.ToDateTime(model.DateStart);
                e.FinishDate = Convert.ToDateTime(model.FinishDate);
                e.ImgPath = path;


                db.SaveChanges();

                return RedirectToAction("Experiences");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult DeleteExp(int id)
        {
            CVProfModel e = db.Profs.Include("Refs").SingleOrDefault(x => x.Id == id);

            if (e.Refs.Count > 0)
            {
                for (int i = 0; i < e.Refs.Count; i++)
                {
                    List<ProfRefs> ps = db.ProRefs.Where(x => x.Exp.Id == id).ToList();
                    foreach (ProfRefs p in ps)
                    {
                        db.ProRefs.Remove(p);
                    }
                    db.SaveChanges();
                }
            }


            db.Profs.Remove(e);
            db.SaveChanges();

            return RedirectToAction("Experiences");
        }

        public ActionResult AddRef()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddRef(ProfRefs model, string ExpId)
        {
            try
            {
                ProfRefs p = new ProfRefs()
                {
                    RefName = model.RefName,
                    RefEmail = model.RefEmail,
                    RefPhone = model.RefPhone,
                    RefRelation = model.RefRelation,
                    RefRelation_Fr=model.RefRelation_Fr,
                    Exp = db.Profs.Find(int.Parse(ExpId))
                };
                db.ProRefs.Add(p);
                db.SaveChanges();

                return RedirectToAction("Experiences");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult EditRef(int id)
        {
            ProfRefs r = db.ProRefs.Find(id);
            return View(r);
        }

        [HttpPost]
        public ActionResult EditRef(ProfRefs model)
        {
            ProfRefs r = db.ProRefs.Find(model.Id);
            try
            {

                r.RefName = model.RefName;
                r.RefEmail = model.RefEmail;
                r.RefPhone = model.RefPhone;
                r.RefRelation = model.RefRelation;
                r.RefRelation_Fr = model.RefRelation_Fr;

                db.SaveChanges();

                return RedirectToAction("Experiences");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult DeleteRef(int id)
        {
            ProfRefs r = db.ProRefs.Find(id);
            db.ProRefs.Remove(r);
            db.SaveChanges();

            return RedirectToAction("Experiences");
        }

        public ActionResult Trainings()
        {
            List<CVTrainingModel> t = db.Trainings.OrderByDescending(x => x.CourceDate).ToList();

            return View(t);
        }

        public ActionResult AddTr()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTr(CVTrainingModel model)
        {
            try
            {
                CVTrainingModel t = new CVTrainingModel()
                {
                    CourseName = model.CourseName,
                    CourseName_Fr=model.CourseName_Fr,
                    Source_Fr=model.Source_Fr,
                    CourceDate = model.CourceDate,
                    Source = model.Source
                };
                db.Trainings.Add(t);
                db.SaveChanges();
                return RedirectToAction("Trainings", "Admin");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult EditTr(int id)
        {
            CVTrainingModel t = db.Trainings.Find(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditTr(CVTrainingModel model)
        {
            try
            {
                CVTrainingModel t = db.Trainings.Find(model.Id);
                t.CourseName = model.CourseName;
                t.CourseName_Fr = model.CourseName_Fr;
                t.CourceDate = model.CourceDate;
                t.Source = model.Source;
                t.Source_Fr = model.Source_Fr;
                db.SaveChanges();

                return RedirectToAction("Trainings");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult DeleteTr(int id)
        {
            CVTrainingModel t = db.Trainings.Find(id);
            db.Trainings.Remove(t);
            db.SaveChanges();
            return RedirectToAction("Trainings");
        }

        public ActionResult Skills()
        {

            return View(db.Skills.OrderBy(x => x.SkillType).ToList());
        }


        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(CVSkillsModel model)
        {
            try
            {
                CVSkillsModel s = new CVSkillsModel()
                {
                    SkillName = model.SkillName,
                    SkillName_Fr = model.SkillName_Fr,
                    SkillType = model.SkillType,
                    SkillType_Fr = model.SkillType_Fr,
                    Desc = model.Desc,
                    Desc_Fr = model.Desc_Fr,
                    Level = model.Level
                };
                db.Skills.Add(s);
                db.SaveChanges();

                Session["success"] = "Skill added successfully";

                return RedirectToAction("Skills");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult EditSkill(int id)
        {
            CVSkillsModel s = db.Skills.Find(id);
            return View(s);
        }

        [HttpPost]
        public ActionResult EditSkill(CVSkillsModel model)
        {
            try
            {
                CVSkillsModel s = db.Skills.Find(model.Id);

                s.SkillName = model.SkillName;
                s.SkillType_Fr = model.SkillType_Fr;
                s.SkillName_Fr = model.SkillName_Fr;
                s.Desc_Fr = model.Desc_Fr;
                s.SkillType = model.SkillType;
                s.Desc = model.Desc;
                s.Level = model.Level;

                db.SaveChanges();

                return RedirectToAction("Skills");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult DeleteSkill(int id)
        {
            CVSkillsModel s = db.Skills.Find(id);
            db.Skills.Remove(s);
            db.SaveChanges();

            Session["success"] = "Skill deleted successfully";

            return RedirectToAction("Skills");
        }

        public ActionResult Languages()
        {
            return View(db.Languages.OrderBy(x => x.Language).ToList());
        }
        
        public ActionResult AddLang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLang(CVLangModel model)
        {
            try
            {
                CVLangModel l = new CVLangModel()
                {
                    Language = model.Language,
                    Language_Fr=model.Language_Fr,
                    SpeakingLevel = model.SpeakingLevel,
                    ListeningLevel = model.ListeningLevel,
                    ReadingLevel = model.ReadingLevel,
                    WritingLevel = model.WritingLevel
                };
                db.Languages.Add(l);
                db.SaveChanges();


                return RedirectToAction("Languages");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult EditLang(int id)
        {
            return View(db.Languages.Find(id));
        }

        [HttpPost]
        public ActionResult EditLang(CVLangModel model)
        {
            try
            {
                CVLangModel l = db.Languages.Find(model.Id);

                l.Language = model.Language;
                l.Language_Fr = model.Language_Fr;
                l.SpeakingLevel = model.SpeakingLevel;
                l.ListeningLevel = model.ListeningLevel;
                l.ReadingLevel = model.ReadingLevel;
                l.WritingLevel = model.WritingLevel;

                db.SaveChanges();


                return RedirectToAction("Languages");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult DeleteLang(int id)
        {
            CVLangModel l = db.Languages.Find(id);
            db.Languages.Remove(l);
            db.SaveChanges();
            return RedirectToAction("Languages");
        }

        public ActionResult Address()
        {
            AddressModel ad = db.Address.OrderByDescending(x => x.Id).FirstOrDefault(); 
            return View(ad);
        }

        [HttpPost]
        public ActionResult Address(AddressModel model)
        {
            try
            {
                AddressModel a = new AddressModel()
                {
                    Name = model.Name,
                    City = model.City,
                    City_Fr=model.City_Fr,
                    Country = model.Country,
                    Country_Fr=model.Country_Fr,
                    CodePostal = model.CodePostal,
                    StreetNo = model.StreetNo,
                    StreetName = model.StreetName,
                    AdditionalInfo = model.AdditionalInfo,
                    AdditionalInfo_Fr=model.AdditionalInfo_Fr,
                    MapCord = model.MapCord
                };
                db.Address.Add(a);
                db.SaveChanges();

                return RedirectToAction("Index", "Admin");
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult SocialLinks()
        {
            SocialModel s = db.Social.FirstOrDefault();
            return View(s);
        }

        [HttpPost]
        public ActionResult SocialLinks(SocialModel model)
        {
            try
            {
                SocialModel s = db.Social.FirstOrDefault();
                s.Facebook = model.Facebook;
                s.LinkedIn = model.LinkedIn;
                db.SaveChanges();

                return RedirectToAction("Index", "Admin");
            }
            catch
            {

            }
            return View(model);
        }


        public ActionResult Messages()
        {
            List<MessageModel> messages = db.Messages.OrderBy(x => x.IsSeen).ThenByDescending(x => x.DT).ToList();
            return View(messages);
        }

        public ActionResult ViewMsg(int id)
        {
            MessageModel msg = db.Messages.Find(id);
            msg.IsSeen = true;
            db.SaveChanges();
            return View(msg);
        }



    



       
	}
}