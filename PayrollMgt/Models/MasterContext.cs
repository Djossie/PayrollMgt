using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PayrollMgt.Models;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allowance> Allowances { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Deduction> Deductions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeePayment> EmployeePayments { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=MS-DARKO\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allowance>(entity =>
        {
            entity.HasKey(e => e.AllowanceId).HasName("PK__allowanc__83B187CF7C50829E");

            entity.ToTable("allowance");

            entity.Property(e => e.AllowanceId)
                .ValueGeneratedNever()
                .HasColumnName("allowance_id");
            entity.Property(e => e.AllowanceDate).HasColumnName("allowance_date");
            entity.Property(e => e.AllowanceType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("allowance_type");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Allowances)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__allowance__emplo__49E3F248");

            entity.HasOne(d => d.Payment).WithMany(p => p.Allowances)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__allowance__payme__4AD81681");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__attendan__C52E0BA86C10656B");

            entity.ToTable("attendance");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.AttendanceDate).HasColumnName("attendance_date");
            entity.Property(e => e.CheckInTime).HasColumnName("check_in_time");
            entity.Property(e => e.CheckOutTime).HasColumnName("check_out_time");
            entity.Property(e => e.Overtime)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithOne(p => p.Attendance)
                .HasForeignKey<Attendance>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__attendanc__emplo__4DB4832C");
        });

        modelBuilder.Entity<Deduction>(entity =>
        {
            entity.HasKey(e => e.DeductionId).HasName("PK__deductio__91FA5431EE87FD71");

            entity.ToTable("deduction");

            entity.Property(e => e.DeductionId)
                .ValueGeneratedNever()
                .HasColumnName("deduction_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.DateOfDeduction).HasColumnName("date_of_deduction");
            entity.Property(e => e.DeductionType)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("deduction_type");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Deductions)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__deduction__emplo__5CF6C6BC");

            entity.HasOne(d => d.Payment).WithMany(p => p.Deductions)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__deduction__payme__5DEAEAF5");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__employee__C52E0BA811B32F64");

            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.Department)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EnrollmentDate).HasColumnName("enrollment_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.JobStatus)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("job_status");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("job_title");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<EmployeePayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__employee__ED1FC9EABF2D603A");

            entity.ToTable("employee_payment");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("payment_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("payment_status");
            entity.Property(e => e.SalaryAmount).HasColumnName("salary_amount");
            entity.Property(e => e.SalaryDate).HasColumnName("salary_date");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeePayments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee___emplo__3F6663D5");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__payment___C52E0BA83CC90C96");

            entity.ToTable("payment_details");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.AccountsName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("accounts_name");
            entity.Property(e => e.AccountsNumber).HasColumnName("accounts_number");
            entity.Property(e => e.BankName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("bank_name");
            entity.Property(e => e.BranchName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("branch_name");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");

            entity.HasOne(d => d.Employee).WithOne(p => p.PaymentDetail)
                .HasForeignKey<PaymentDetail>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__payment_d__emplo__536D5C82");

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__payment_d__payme__546180BB");
        });

 

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
