using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PayrollMgt.Models;

public partial class EmployeePayment
{
    public int PaymentId { get; set; }

    public int EmployeeId { get; set; }

    public int? SalaryAmount { get; set; }

    public DateOnly? SalaryDate { get; set; }

    public string? PaymentStatus { get; set; }

    [IgnoreDataMember]
    public virtual ICollection<Allowance> Allowances { get; set; } = new List<Allowance>();
    [IgnoreDataMember]
    public virtual ICollection<Deduction> Deductions { get; set; } = new List<Deduction>();
    [IgnoreDataMember]
    public virtual Employee Employee { get; set; } = null!;

    [IgnoreDataMember] 
    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}
