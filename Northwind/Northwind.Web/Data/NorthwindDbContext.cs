namespace Northwind.Web.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class NorthwindDbContext : DbContext
{
  public DbSet<Customer> Customers => Set<Customer>();
  public DbSet<Employee> Employees => Set<Employee>();

  public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
    : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Employee>().Property(x => x.Id).HasColumnName("EmployeeId");
    builder.Entity<Employee>().Property(x => x.ManagerId).HasColumnName("ReportsTo");
    
    base.OnModelCreating(builder);
  }
}