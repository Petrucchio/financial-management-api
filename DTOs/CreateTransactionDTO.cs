using System.ComponentModel.DataAnnotations;
using FinancialManagementAPI.Models;

namespace FinancialManagementAPI.DTOs
{
    public class CreateTransactionDTO
    {
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(200, ErrorMessage = "Description must be at most 200 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Transaction type is required.")]
        public TransactionType Type { get; set; }
    }
}