using Microsoft.AspNetCore.Mvc;
using FinancialManagementAPI.DTOs;
using FinancialManagementAPI.Services;

namespace FinancialManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _service;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(
            ITransactionService service,
            ILogger<TransactionsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>Returns all transactions ordered by date.</summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransactionDTO>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all transactions.");
            return Ok(_service.GetAll());
        }

        /// <summary>Returns a transaction by ID.</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransactionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Fetching transaction with ID: {Id}", id);

            var transaction = _service.GetById(id);
            if (transaction == null)
            {
                _logger.LogWarning("Transaction with ID {Id} not found.", id);
                return NotFound();
            }

            return Ok(transaction);
        }

        /// <summary>Returns transactions filtered by category.</summary>
        [HttpGet("category/{category}")]
        [ProducesResponseType(typeof(IEnumerable<TransactionDTO>), StatusCodes.Status200OK)]
        public IActionResult GetByCategory(string category)
        {
            _logger.LogInformation("Fetching transactions for category: {Category}", category);
            return Ok(_service.GetByCategory(category));
        }

        /// <summary>Creates a new transaction.</summary>
        [HttpPost]
        [ProducesResponseType(typeof(TransactionDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateTransactionDTO dto)
        {
            _logger.LogInformation("Creating new transaction: {Description}", dto.Description);

            var result = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}