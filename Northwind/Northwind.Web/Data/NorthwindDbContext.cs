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

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Employee>().Property(x => x.Id).HasColumnName("EmployeeId");
    
    //modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthwindDbContext).Assembly);
    base.OnModelCreating(modelBuilder);
  }
}