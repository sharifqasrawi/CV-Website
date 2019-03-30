using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_Personal_Website.Models
{
    public class ContactModel
    {
        public MessageModel Message { get; set; }
        public AddressModel Address { get; set; }
        public SocialModel Social { get; set; }
    }
}