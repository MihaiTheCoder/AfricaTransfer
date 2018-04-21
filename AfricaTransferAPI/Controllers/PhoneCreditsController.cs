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
    [Route("api/PhoneCredits")]
    public class PhoneCreditsController : Controller
    {
        private readonly AfricaTransferContext _context;

        public PhoneCreditsController(AfricaTransferContext context)
        {
            _context = context;
        }

        // GET: api/PhoneCredits
        [HttpGet]
        public IEnumerable<PhoneCredit> GetPhoneCredit()
        {
            return _context.PhoneCredit;
        }

        // GET: api/PhoneCredits/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneCredit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phoneCredit = await _context.PhoneCredit.SingleOrDefaultAsync(m => m.ID == id);

            if (phoneCredit == null)
            {
                return NotFound();
            }

            return Ok(phoneCredit);
        }

        // PUT: api/PhoneCredits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneCredit([FromRoute] int id, [FromBody] PhoneCredit phoneCredit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneCredit.ID)
            {
                return BadRequest();
            }

            _context.Entry(phoneCredit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneCreditExists(id))
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

        // POST: api/PhoneCredits
        [HttpPost]
        public async Task<IActionResult> PostPhoneCredit([FromBody] PhoneCredit phoneCredit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PhoneCredit.Add(phoneCredit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneCredit", new { id = phoneCredit.ID }, phoneCredit);
        }

        // DELETE: api/PhoneCredits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneCredit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phoneCredit = await _context.PhoneCredit.SingleOrDefaultAsync(m => m.ID == id);
            if (phoneCredit == null)
            {
                return NotFound();
            }

            _context.PhoneCredit.Remove(phoneCredit);
            await _context.SaveChangesAsync();

            return Ok(phoneCredit);
        }

        private bool PhoneCreditExists(int id)
        {
            return _context.PhoneCredit.Any(e => e.ID == id);
        }
    }
}