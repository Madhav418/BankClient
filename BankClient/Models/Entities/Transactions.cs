using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankClient.Models.Entities
{
    public class Transactions
    {
        public string TransactionId { set; get; }
        [Required(ErrorMessage = "Transaction Type is required")]
        public string TransactionType { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Account Number must be a positive integer")]
        public int AccountNo { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        public float Amount { get; set; }

        [Required(ErrorMessage = "Transaction Date is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format")]
        public DateTime TransactionDate { get; set; }


    }
}