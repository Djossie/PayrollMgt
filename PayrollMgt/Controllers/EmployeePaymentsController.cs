using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollMgt.Models;

namespace PayrollMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePaymentsController : ControllerBase
    {
        private readonly MasterContext _context;

        public EmployeePaymentsController(MasterContext context)
        {
            _context = context;
        }

        // GET: api/EmployeePayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeePayment>>> GetEmployeePayments()
        {
            return await _context.EmployeePayments.ToListAsync();
        }

        // GET: api/EmployeePayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeePayment>> GetEmployeePayment(int id)
        {
            var employeePayment = await _context.EmployeePayments.FindAsync(id);

            if (employeePayment == null)
            {
                return NotFound();
            }

            return employeePayment;
        }

        // PUT: api/EmployeePayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeePayment(int id, EmployeePayment employeePayment)
        {
            if (id != employeePayment.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(employeePayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeePaymentExists(id))
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

        // POST: api/EmployeePayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeePayment>> PostEmployeePayment(EmployeePayment employeePayment)
        {
            _context.EmployeePayments.Add(employeePayment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)           {
                if (EmployeePaymentExists(employeePayment.PaymentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeePayment", new { id = employeePayment.PaymentId }, employeePayment);
        }

        // DELETE: api/EmployeePayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeePayment(int id)
        {
            var employeePayment = await _context.EmployeePayments.FindAsync(id);
            if (employeePayment == null)
            {
                return NotFound();
            }

            _context.EmployeePayments.Remove(employeePayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeePaymentExists(int id)
        {
            return _context.EmployeePayments.Any(e => e.PaymentId == id);
        }
    }
}
