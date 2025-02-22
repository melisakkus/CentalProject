using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class GeneralInfo : BaseEntity
    {
        public int GeneralInfoId { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string SocialMediaAddress1 { get; set; }
        public string SocialMediaAddress2 { get; set; }
        public string SocialMediaAddress3 { get; set; }
        public string SocialMediaAddress4 { get; set; }
        public string OpeningHours { get; set; }
        public string ClosingHourse { get; set; }
    }
}
