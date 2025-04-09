using System;
using System.ComponentModel.DataAnnotations;

namespace ReceiptReimbursementAPI.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; }

        public string FilePath { get; set; }
    }
}
