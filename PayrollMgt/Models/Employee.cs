using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace PayrollMgt.Models;

public partial class Employee
{
    
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string JobTitle { get; set; } = null!;

    public string? Department { get; set; }

    public DateOnly? EnrollmentDate { get; set; }

    public string? JobStatus { get; set; }

    public string? Username { get; set; } = null;

    public string? PasswordHash { get; set; }= null;

    public virtual ICollection<Allowance> Allowances { get; set; } = new List<Allowance>();

    public virtual Attendance? Attendance { get; set; }

    public virtual ICollection<Deduction> Deductions { get; set; } = new List<Deduction>();

    public virtual ICollection<EmployeePayment> EmployeePayments { get; set; } = new List<EmployeePayment>();

    public virtual PaymentDetail? PaymentDetail { get; set; }
  
}
