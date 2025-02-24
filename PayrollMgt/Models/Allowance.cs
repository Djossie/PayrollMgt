using System;
using System.Collections.Generic;

namespace PayrollMgt.Models;

public partial class Allowance
{
    public int AllowanceId { get; set; }

    public string? AllowanceType { get; set; }

    public int? EmployeeId { get; set; }

    public int? PaymentId { get; set; }

    public int? Amount { get; set; }

    public DateOnly? AllowanceDate { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual EmployeePayment? Payment { get; set; }
}
