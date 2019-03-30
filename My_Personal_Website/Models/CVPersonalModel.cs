using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace My_Personal_Website.Models
{
   
    public class CVPersonalModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Desc { get; set; }

        [DataType(DataType.Text)]
        public string Desc_Fr { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Text)]
        public string Telephone { get; set;}

        [DataType(DataType.Text)]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        public string ImagePath { get; set; }

        public string CVPath { get; set; }

    }
}