using FinancialManagementAPI.Models;

namespace FinancialManagementAPI.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAll();
        Transaction? GetById(int id);
        IEnumerable<Transaction> GetByCategory(string category);
        void Add(Transaction transaction);
    }
}