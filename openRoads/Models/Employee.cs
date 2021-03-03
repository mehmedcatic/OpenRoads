using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace openRoadsWebAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public DateTime HireDate { get; set; }
        public string EmployeeCode { get; set; }
        public string JobDescription { get; set; }
        public bool Active { get; set; }


        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
