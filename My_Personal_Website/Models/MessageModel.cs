using My_Personal_Website.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class MessageModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Subject", ResourceType = typeof(Resource))]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Text", ResourceType = typeof(Resource))]

        public string Msg { get; set; }

        [Display(Name = "DT", ResourceType = typeof(Resource))]
        public DateTime DT { get; set; }

        [Display(Name = "Seen", ResourceType = typeof(Resource))]
        public bool IsSeen { get; set; }
        
    }
}