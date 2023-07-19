namespace Northwind.Web.Models;

using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using Microsoft.AspNetCore.Authorization;

[Resource]
public class Employee : Identifiable<int>
{
  [HasOne]
  public Employee? Manager { get; set; }
  
  [HasMany]
  public ICollection<Employee>? DirectReports { get; private set; } = new HashSet<Employee>();
  
  [Attr]
  public string FirstName { get; set; }
  [Attr]
  public string LastName { get; set; }

  [NotMapped]
  public int? ManagerId { get; set; }
  
}