using System;
using System.Collections.Generic;

namespace PayrollMgt.Models;

public partial class Attendance
{
    public int EmployeeId { get; set; }

    public TimeOnly? CheckInTime { get; set; }

    public TimeOnly? CheckOutTime { get; set; }

    public string? Overtime { get; set; }

    public DateOnly? AttendanceDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
