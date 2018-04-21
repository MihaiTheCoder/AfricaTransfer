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
    [Route("api/AuthModels")]
    public class AuthModelsController : Controller
    {
        private readonly AfricaTransferContext _context;

        public AuthModelsController(AfricaTransferContext context)
        {
            _context = context;
        }

        // GET: api/AuthModels
        [HttpGet]
        public IEnumerable<AuthModel> GetAuthModel()
        {
            return _context.AuthModel;
        }

        // GET: api/AuthModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authModel = await _context.AuthModel.SingleOrDefaultAsync(m => m.ID == id);

            if (authModel == null)
            {
                return NotFound();
            }

            return Ok(authModel);
        }

        // PUT: api/AuthModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthModel([FromRoute] int id, [FromBody] AuthModel authModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(authModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthModelExists(id))
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

        // POST: api/AuthModels
        [HttpPost]
        public async Task<IActionResult> PostAuthModel([FromBody] AuthModel authModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AuthModel.Add(authModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthModel", new { id = authModel.ID }, authModel);
        }

        // DELETE: api/AuthModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authModel = await _context.AuthModel.SingleOrDefaultAsync(m => m.ID == id);
            if (authModel == null)
            {
                return NotFound();
            }

            _context.AuthModel.Remove(authModel);
            await _context.SaveChangesAsync();

            return Ok(authModel);
        }

        private bool AuthModelExists(int id)
        {
            return _context.AuthModel.Any(e => e.ID == id);
        }
    }
}