using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankClient.Models.Entities
{
    public class FeedBackModel
    {

        public int SNO { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a feedback type.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please select a feedback topic.")]
        public string EnquiryOn { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]

        [RegularExpression(pattern: @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+$", ErrorMessage = " Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your contact number.")]
        [RegularExpression(pattern: @"^[6-9]{1}[0-9]{9}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }


    }

    }
