using My_Personal_Website.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class CVLangModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Language", ResourceType = typeof(Resource))]
        public string Language { get; set; }

        [Required]
        [Display(Name = "Language", ResourceType = typeof(Resource))]
        public string Language_Fr { get; set; }

        [Required]
        [Display(Name = "SpkLevel", ResourceType = typeof(Resource))]
        public int SpeakingLevel { get; set; }

        [Required]
        [Display(Name = "LstLevel", ResourceType = typeof(Resource))]
        public int ListeningLevel { get; set; }

        [Required]
        [Display(Name = "RdLevel", ResourceType = typeof(Resource))]
        public int ReadingLevel { get; set; }

        [Required]
        [Display(Name = "WrLevel", ResourceType = typeof(Resource))]
        public int WritingLevel { get; set; }
    }
}