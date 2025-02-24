using Microsoft.EntityFrameworkCore;
using PayrollMgt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollMgt.PayRoll_Service
{
    public class PayRollService
    {

        private readonly MasterContext _masterContext;
        public PayRollService(MasterContext context)
        {
            _masterContext = context;
            Console.WriteLine("Service Instantiated!");
        }

        public async Task
            ProcessPayRollAsync()
        {
            Console.WriteLine("Processing Payroll...");

            await Task.Delay(1000);
        }


        public async Task CalculatePayroll()
        {
            var payrollRecords = new List<EmployeePayment>();

            var employees = await _masterContext.Employees.ToListAsync();


            foreach (var employee in employees)
            {
                var salary_amount = await _masterContext.EmployeePayments.AsNoTracking().FirstOrDefaultAsync
                    (p => p.EmployeeId == employee.EmployeeId);



                var Allowances = await _masterContext.Allowances.Where(
                    a => a.EmployeeId == employee.EmployeeId).
                    SumAsync(a => a.Amount);

                var Deductions = await _masterContext.Deductions.Where(
                    d => d.EmployeeId == employee.EmployeeId).
                    SumAsync(d => d.Amount);

                decimal salaryAmount = salary_amount?.SalaryAmount ?? 0;
                decimal totalAmount = (decimal)(salaryAmount + Allowances - Deductions);


                DateTime dateTime = DateTime.Now;
                payrollRecords.Add(new EmployeePayment
                {
                    EmployeeId = employee.EmployeeId,
                    SalaryAmount = (int?)salaryAmount,
                    SalaryDate = DateOnly.FromDateTime(dateTime)
                });

                Console.WriteLine($"Employee: {employee.FirstName}, Total Salary: {totalAmount:C}");
            }

            _masterContext.ChangeTracker.Clear();
            await _masterContext.EmployeePayments.AddRangeAsync();
            await _masterContext.SaveChangesAsync();

            Console.WriteLine("Payroll processed and saved.");
            Console.WriteLine($"Payment made successfully at {DateTime.Now}");
        }
    }
}
