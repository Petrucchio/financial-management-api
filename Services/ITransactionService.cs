using FinancialManagementAPI.DTOs;

namespace FinancialManagementAPI.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionDTO> GetAll();
        TransactionDTO? GetById(int id);
        TransactionDTO Create(CreateTransactionDTO dto);
    }
}