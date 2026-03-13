using FinancialManagementAPI.Models;

namespace FinancialManagementAPI.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
    }
}