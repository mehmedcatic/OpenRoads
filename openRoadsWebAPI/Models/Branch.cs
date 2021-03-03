using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZIPCode { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkingHoursFrom { get; set; }
        public int WorkingHoursTo { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
