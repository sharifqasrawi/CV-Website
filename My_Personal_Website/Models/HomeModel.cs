using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class HomeModel
    {
        public CVPersonalModel Personal { get; set; }
        public List<CVEduModel> Educations { get; set; }
        public List<CVProfModel> Profs { get; set; }
        public List<CVLangModel> Languages { get; set; }
        public List<CVTrainingModel> Trainings { get; set; }
        public List<CVSkillsModel> Skills { get; set; }
    }
}