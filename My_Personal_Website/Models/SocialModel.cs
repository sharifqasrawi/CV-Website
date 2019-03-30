using My_Personal_Website.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class SocialModel
    {
        public int Id { get; set; }

        public string Facebook { get; set; }

        public string LinkedIn { get; set; }
    }
}