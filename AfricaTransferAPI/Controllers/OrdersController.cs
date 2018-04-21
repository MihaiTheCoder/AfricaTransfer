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
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private readonly AfricaTransferContext _context;

        public OrdersController(AfricaTransferContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> GetOrder()
        {
            return _context.Order;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Order.SingleOrDefaultAsync(m => m.ID == id);

            if (order == null)
            {
                return NotFound();
            }

            order.OrderLines = _context.OrderLine.Where(ol => ol.OrderID == order.ID).ToList();

            return Ok(order);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromRoute] int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.ID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            if(order.Status ==OrderStatus.Confirmed)
            {
                var ammount = order.OrderLines.Sum(o => o.ProductPrice);

                _context.MobileTransaction.Add(new MobileTransaction {
                    DestinationAuthModelID = order.SellerID,
                    SourceAuthModelID = order.BuyerID.Value,
                    Ammount = ammount
                });

                var sellerPhoneCredit = _context.PhoneCredit.First(am => am.AuthModelID == order.SellerID);
                sellerPhoneCredit.Credit += ammount;

                var buyerPhoneCredit = _context.PhoneCredit.First(am => am.AuthModelID == order.BuyerID);
                buyerPhoneCredit.Credit -= ammount;

                if (buyerPhoneCredit.Credit <= 0)
                    return BadRequest();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Order.Add(order);

            foreach (var ord in order.OrderLines)
            {
                var product = _context.Product.First(p => p.ID == ord.ProductID);
                ord.ProductPrice = product.Price;
            }

            await _context.SaveChangesAsync();            

            return CreatedAtAction("GetOrder", new { id = order.ID }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Order.SingleOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.ID == id);
        }
    }
}