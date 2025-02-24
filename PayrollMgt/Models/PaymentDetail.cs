using System;
using System.Collections.Generic;

namespace PayrollMgt.Models;

public partial class PaymentDetail
{
    public int EmployeeId { get; set; }

    public string BankName { get; set; } = null!;

    public int AccountsNumber { get; set; }

    public string AccountsName { get; set; } = null!;

    public string BranchName { get; set; } = null!;

    public int? PaymentId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual EmployeePayment? Payment { get; set; }
}
