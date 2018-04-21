using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AfricaTransfer.CoreLib.Models;

namespace AfricaTransferAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/BankTransactions")]
    public class BankTransactionsController : Controller
    {
        private readonly AfricaTransferContext _context;

        public BankTransactionsController(AfricaTransferContext context)
        {
            _context = context;
        }

        // GET: api/BankTransactions
        [HttpGet]
        public IEnumerable<BankTransaction> GetBankTransaction()
        {
            return _context.BankTransaction;
        }

        // GET: api/BankTransactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bankTransaction = await _context.BankTransaction.SingleOrDefaultAsync(m => m.ID == id);

            if (bankTransaction == null)
            {
                return NotFound();
            }

            return Ok(bankTransaction);
        }        

        // POST: api/BankTransactions
        [HttpPost]
        public async Task<IActionResult> PostBankTransaction([FromBody] BankTransaction bankTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var phoneCredit = _context.PhoneCredit.First
                (pc => pc.AuthModelID == bankTransaction.DestinationAuthModelID);

            phoneCredit.Credit += bankTransaction.Ammount;
            _context.BankTransaction.Add(bankTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankTransaction", new { id = bankTransaction.ID }, bankTransaction);
        }

        // DELETE: api/BankTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bankTransaction = await _context.BankTransaction.SingleOrDefaultAsync(m => m.ID == id);
            if (bankTransaction == null)
            {
                return NotFound();
            }

            _context.BankTransaction.Remove(bankTransaction);
            await _context.SaveChangesAsync();

            return Ok(bankTransaction);
        }

        private bool BankTransactionExists(int id)
        {
            return _context.BankTransaction.Any(e => e.ID == id);
        }
    }
}