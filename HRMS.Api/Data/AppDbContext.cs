using HRMS.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<Leave> Leaves { get; set; }
    public DbSet<LeaveDetail> LeaveDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Leave to LeaveType: One LeaveType can have many Leaves
        modelBuilder.Entity<Leave>()
            .HasOne(l => l.LeaveType)
            .WithMany()
            .HasForeignKey(l => l.LeaveTypeId)
            .OnDelete(DeleteBehavior.Restrict); // Optional: Define delete behavior

        // Leave to Employee: One Employee can have many Leaves
        modelBuilder.Entity<Leave>()
            .HasOne(l => l.Employee)
            .WithMany()
            .HasForeignKey(l => l.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict); // Optional: Define delete behavior
        
        // Leave to LeaveDetail: One Leave can have many LeaveDetails
        modelBuilder.Entity<Leave>()
            .HasMany(l => l.LeaveDetails)
            .WithOne(ld => ld.Leave)
            .HasForeignKey(ld => ld.LeaveId)
            .OnDelete(DeleteBehavior.Cascade); // Optional: Define delete behavior

        base.OnModelCreating(modelBuilder);
    }
}