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
    [Route("api/MobileTransactions")]
    public class MobileTransactionsController : Controller
    {
        private readonly AfricaTransferContext _context;

        public MobileTransactionsController(AfricaTransferContext context)
        {
            _context = context;
        }

        // GET: api/MobileTransactions
        [HttpGet]
        public IEnumerable<MobileTransaction> GetMobileTransaction()
        {
            return _context.MobileTransaction;
        }

        // GET: api/MobileTransactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMobileTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mobileTransaction = await _context.MobileTransaction.SingleOrDefaultAsync(m => m.ID == id);

            if (mobileTransaction == null)
            {
                return NotFound();
            }

            return Ok(mobileTransaction);
        }

        // PUT: api/MobileTransactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobileTransaction([FromRoute] int id, [FromBody] MobileTransaction mobileTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mobileTransaction.ID)
            {
                return BadRequest();
            }

            _context.Entry(mobileTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileTransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MobileTransactions
        [HttpPost]
        public async Task<IActionResult> PostMobileTransaction([FromBody] MobileTransaction mobileTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MobileTransaction.Add(mobileTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobileTransaction", new { id = mobileTransaction.ID }, mobileTransaction);
        }

        // DELETE: api/MobileTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMobileTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mobileTransaction = await _context.MobileTransaction.SingleOrDefaultAsync(m => m.ID == id);
            if (mobileTransaction == null)
            {
                return NotFound();
            }

            _context.MobileTransaction.Remove(mobileTransaction);
            await _context.SaveChangesAsync();

            return Ok(mobileTransaction);
        }

        private bool MobileTransactionExists(int id)
        {
            return _context.MobileTransaction.Any(e => e.ID == id);
        }
    }
}