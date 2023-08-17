using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankClient.Models.Entities
{
    public class AdminLogin
    {
        [Key]
        [Required(ErrorMessage = "EmployeeId is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "EmployeeId should be between 5 and 20 characters.")]
        public string EmployeeId { set; get; }
        [Required(ErrorMessage = "Password is required.")]
       
        public string Password { set; get; }
    }
}