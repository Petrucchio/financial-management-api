using FinancialManagementAPI.DTOs;
using FinancialManagementAPI.Models;

namespace FinancialManagementAPI.Services
{
    public class TransactionService : ITransactionService
    {
        private static readonly List<Transaction> _transactions = new();
        private static int _nextId = 1;

        public IEnumerable<TransactionDTO> GetAll()
        {
            return _transactions.Select(MapToDTO);
        }

        public TransactionDTO? GetById(int id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null) return null;
            return MapToDTO(transaction);
        }

        public TransactionDTO Create(CreateTransactionDTO dto)
        {
            var transaction = new Transaction
            {
                Id = _nextId++,
                Description = dto.Description,
                Amount = dto.Amount,
                Category = dto.Category,
                Type = dto.Type,
                Date = DateTime.UtcNow
            };

            _transactions.Add(transaction);
            return MapToDTO(transaction);
        }

        private static TransactionDTO MapToDTO(Transaction t) => new()
        {
            Id = t.Id,
            Description = t.Description,
            Amount = t.Amount,
            Category = t.Category,
            Date = t.Date,
            Type = t.Type
        };
    }
}