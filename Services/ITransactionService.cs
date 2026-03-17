using FinancialManagementAPI.DTOs;

namespace FinancialManagementAPI.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionDTO> GetAll();
        TransactionDTO? GetById(int id);
        IEnumerable<TransactionDTO> GetByCategory(string category);
        TransactionDTO Create(CreateTransactionDTO dto);
    }
}