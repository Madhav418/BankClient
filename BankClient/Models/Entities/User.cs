using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankClient.Models.Entities
{
    public class User
    {
        [Required(ErrorMessage = "User ID is required.")]
        [RegularExpression(@"^U.*$", ErrorMessage = "User ID must start with letter 'U'")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "User ID must have at least 2 characters.")]
        public string UserId { get; set; }


        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?\d{1,4}[-. ]?\d{1,3}[-. ]?\d{4,10}$", ErrorMessage = "Invalid Phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DateOfBirthValidation(10, ErrorMessage = "Invalid Date of Birth. The user must be at least 10 years old.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Account Number is required.")]
        public int AccountNo { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password should contain at least one uppercase letter, one lowercase letter, and one digit.")]
        public string Password { get; set; }
    }
}