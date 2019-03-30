using My_Personal_Website.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class CVSkillsModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "SkillName", ResourceType = typeof(Resource))]
        public string SkillName { get; set;}

        [Required]
        [Display(Name = "SkillName", ResourceType = typeof(Resource))]
        public string SkillName_Fr { get; set; }

        [Required]
        [Display(Name = "Type", ResourceType = typeof(Resource))]
        public string SkillType { get; set; }

        [Required]
        [Display(Name = "Type", ResourceType = typeof(Resource))]
        public string SkillType_Fr { get; set; }

        [Required]
        [Display(Name = "Level", ResourceType = typeof(Resource))]
        public int Level { get; set; }
        public string Level1 { get; set; }
        public string Desc { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resource))]
        public string Desc_Fr { get; set; }
    }
}