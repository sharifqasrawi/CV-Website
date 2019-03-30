using My_Personal_Website.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class CVProfModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Position", ResourceType = typeof(Resource))]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Position", ResourceType = typeof(Resource))]
        public string Position_Fr { get; set; }

        [Required]
        [Display(Name = "Company", ResourceType = typeof(Resource))]
        public string Company { get; set; }

        [Required]
        [Display(Name = "Company", ResourceType = typeof(Resource))]
        public string Company_Fr { get; set; }


        [Display(Name = "CmpyWebsite", ResourceType = typeof(Resource))]
        public string CompanyWebsite { get; set; }

        [Required]
        [Display(Name = "StartDate", ResourceType = typeof(Resource))]
        public DateTime DateStart { get; set; }

        [Required]
        [Display(Name = "FinishDate", ResourceType = typeof(Resource))]
        public DateTime FinishDate { get; set; }

         [Display(Name = "CertImage", ResourceType = typeof(Resource))]
        public string ImgPath { get; set; }

         [Display(Name = "Description", ResourceType = typeof(Resource))]
        public string Desc { get; set; }

         [Display(Name = "Description", ResourceType = typeof(Resource))]
         public string Desc_Fr { get; set; }

        public List<ProfRefs> Refs { get; set; }

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
        
    }

    public class ProfRefs
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resource))]
        public string RefName { get; set; }

         [Display(Name = "PhoneNum", ResourceType = typeof(Resource))]
        public string RefPhone { get; set; }

         [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string RefEmail { get; set; }

        [Required]
        [Display(Name = "Relation", ResourceType = typeof(Resource))]
        public string RefRelation { get; set; }

        [Required]
        [Display(Name = "Relation", ResourceType = typeof(Resource))]
        public string RefRelation_Fr { get; set; }
        public CVProfModel Exp { get; set; }
    }
}