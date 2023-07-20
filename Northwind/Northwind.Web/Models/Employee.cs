namespace Northwind.Web.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

[Resource]
public class Employee : Identifiable<int>
{
  [HasOne]
  public Employee? Manager { get; set; }
  
  [HasMany]
  public ICollection<Employee>? DirectReports { get; private set; } = new HashSet<Employee>();

  [Attr] 
  [MaxLength(10)] 
  [Required] 
  public string FirstName { get; set; }
  [Attr] 
  [MaxLength(10)] 
  [Required] 
  public string LastName { get; set; }

  [NotMapped]
  public int? ManagerId { get; set; }
  
}