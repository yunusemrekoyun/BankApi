using Microsoft.AspNetCore.Mvc;
using BankApi.data;
using BankApi.models;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly bankContext _context;

        public TransactionsController(bankContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaction([FromBody] Transaction transaction)
        {

            var sender = await _context.People.FindAsync(transaction.SenderId);
            var receiver = await _context.People.FindAsync(transaction.ReceiverId);
            Console.WriteLine("transaction");
            if (sender == null || receiver == null)
            {
                return NotFound("Sender or receiver not found.");
            }

            if (sender.Balance >= transaction.Amount)
            {
                sender.Balance -= transaction.Amount;
                receiver.Balance += transaction.Amount;

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                return Ok(transaction);
            }

            return BadRequest("Insufficient funds.");
        }
    }
}
