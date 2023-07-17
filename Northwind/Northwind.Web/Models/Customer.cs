namespace Northwind.Web.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

[Resource]
public class Customer : IIdentifiable<string>
{
  [Key]
  [Column("CustomerId")]
  public string Id { get; set; }
  
  [Attr]
  public string CompanyName { get; set; }
  [Attr]
  public string ContactName { get; set; }

  [NotMapped]
  public string? StringId { get; set; }
  
  [NotMapped]
  public string? LocalId { get; set; }
  
}