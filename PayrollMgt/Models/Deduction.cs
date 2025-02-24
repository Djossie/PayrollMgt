using System;
using System.Collections.Generic;

namespace PayrollMgt.Models;

public partial class Deduction
{
    public int DeductionId { get; set; }

    public int? EmployeeId { get; set; }

    public int? PaymentId { get; set; }

    public string? DeductionType { get; set; }

    public int? Amount { get; set; }

    public DateOnly? DateOfDeduction { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual EmployeePayment? Payment { get; set; }
}
