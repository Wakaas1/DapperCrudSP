using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStoredProc.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
       
        //public string Response { get; set; }
    }
}
