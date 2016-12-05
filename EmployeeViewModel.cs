using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public class EmployeeViewModel
    {
        [Required]
        [Display(Name = "employeeId")]
        public int employeeId { get; set; }

        [Required]
        [Display(Name = "roleId")]
        public int roleId { get; set; }
    }


}

