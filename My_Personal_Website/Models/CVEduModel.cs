using My_Personal_Website.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class CVEduModel
    {
        public int Id { get; set;}

        [Required]
        [Display(Name = "Degree", ResourceType = typeof(Resource))]
        public string Degree { get; set; }

        [Required]
        [Display(Name = "Degree", ResourceType = typeof(Resource))]
        public string Degree_Fr { get; set; }

        [Required]
        [Display(Name = "Major", ResourceType = typeof(Resource))]
        public string Major { get; set; }

        [Required]
        [Display(Name = "Major", ResourceType = typeof(Resource))]
        public string Major_Fr { get; set; }


        [Required]
        [Display(Name = "University", ResourceType = typeof(Resource))]
        public string University { get; set; }

        [Required]
        [Display(Name = "University", ResourceType = typeof(Resource))]
        public string University_Fr { get; set; }


        [Display(Name = "UniversityWebsite", ResourceType = typeof(Resource))]
        public string UniversityWebsite { get; set; }

        [Required]
        [Display(Name = "Country", ResourceType = typeof(Resource))]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Country", ResourceType = typeof(Resource))]
        public string Country_Fr { get; set; }

        [Required]
        [Display(Name = "City", ResourceType = typeof(Resource))]
        public string City { get; set; }

        [Required]
        [Display(Name = "City", ResourceType = typeof(Resource))]
        public string City_Fr { get; set; }


        [Required]
        [Display(Name = "StartDate", ResourceType = typeof(Resource))]
        public string DateStart { get; set; }

        [Required]
        [Display(Name = "FinishDate", ResourceType = typeof(Resource))]
        public string DateFinish { get; set; }

        [Required]
        [Display(Name = "Score", ResourceType = typeof(Resource))]
        public Double Score { get; set; }

        [Display(Name = "DegImg", ResourceType = typeof(Resource))]
        public string ImgPath { get; set; }

        public List<EduProject> Projects { get; set; }
    }

    public class EduProject
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ProjectNAme", ResourceType = typeof(Resource))]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "ProjectNAme", ResourceType = typeof(Resource))]
        public string ProjectName_Fr { get; set; }


        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resource))]
        public string ProjectDesc { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resource))]
        public string ProjectDesc_Fr { get; set; }


        [Display(Name = "ProjectLink", ResourceType = typeof(Resource))]
        public string ProjectLink { get; set; }

        [Display(Name = "Score", ResourceType = typeof(Resource))]
        public double Score { get; set; }
        public CVEduModel Edu { get; set; }
    }
}