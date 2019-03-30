using My_Personal_Website.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class AddressModel
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resource))]
        public string City { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resource))]
        public string City_Fr { get; set; }


        [Display(Name = "Country", ResourceType = typeof(Resource))]
        public string Country { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resource))]
        public string Country_Fr { get; set; }



        [Display(Name = "CodePostal", ResourceType = typeof(Resource))]
        public string CodePostal { get; set; }

        [Display(Name = "StreetNo", ResourceType = typeof(Resource))]
        public string StreetNo { get; set; }

        [Display(Name = "StreetName", ResourceType = typeof(Resource))]
        public string StreetName { get; set; }

        [Display(Name = "AdditionalInfo", ResourceType = typeof(Resource))]
        public string AdditionalInfo { get; set; }

        [Display(Name = "AdditionalInfo", ResourceType = typeof(Resource))]
        public string AdditionalInfo_Fr { get; set; }

        [Display(Name = "MapLink", ResourceType = typeof(Resource))]
        public string MapCord { get; set; }
    }
}