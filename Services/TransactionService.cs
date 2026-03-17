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

        private IQueryable<Transaction> Query()
        {
            return _context.Transactions.AsNoTracking();
        }

        public IEnumerable<TransactionDTO> GetAll()
        {
            return Query()
                .OrderByDescending(t => t.Date)
                .Select(t => MapToDTO(t))
                .ToList();
        }

        public TransactionDTO? GetById(int id)
        {
            var transaction = Query()
                .FirstOrDefault(t => t.Id == id);

            if (transaction == null) return null;

            return MapToDTO(transaction);
        }

        public IEnumerable<TransactionDTO> GetByCategory(string category)
        {
            return Query()
                .Where(t => t.Category.ToLower() == category.ToLower())
                .OrderByDescending(t => t.Date)
                .Select(t => MapToDTO(t))
                .ToList();
        }

        public TransactionDTO Create(CreateTransactionDTO dto)
        {
            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

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