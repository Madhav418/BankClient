using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankClient.Models.Entities
{
    public class login
    {
        [Required(ErrorMessage = "User ID is required.")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Password is required.")]
      
        public string Password { get; set; }
        public bool rememberMe { get; set; }
    }
}