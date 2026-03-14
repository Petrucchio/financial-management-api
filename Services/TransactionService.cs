using Microsoft.EntityFrameworkCore;
using FinancialManagementAPI.Data;
using FinancialManagementAPI.DTOs;
using FinancialManagementAPI.Models;

namespace FinancialManagementAPI.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TransactionDTO> GetAll()
        {
            return _context.Transactions
                .AsNoTracking()
                .Select(t => MapToDTO(t))
                .ToList();
        }

        public TransactionDTO? GetById(int id)
        {
            var transaction = _context.Transactions
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == id);

            if (transaction == null) return null;

            return MapToDTO(transaction);
        }

        public TransactionDTO Create(CreateTransactionDTO dto)
        {
            var transaction = new Transaction
            {
                Description = dto.Description,
                Amount = dto.Amount,
                Category = dto.Category,
                Type = dto.Type,
                Date = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

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