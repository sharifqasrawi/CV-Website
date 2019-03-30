using My_Personal_Website.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class CVTrainingModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "CourseName", ResourceType = typeof(Resource))]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "CourseName", ResourceType = typeof(Resource))]
        public string CourseName_Fr { get; set; }

        [Required]
        [Display(Name = "CourseDate", ResourceType = typeof(Resource))]
        public string CourceDate { get; set; }

        [Display(Name = "Source", ResourceType = typeof(Resource))]
        public string Source { get; set; }

        [Display(Name = "Source", ResourceType = typeof(Resource))]
        public string Source_Fr { get; set; }
    }
}