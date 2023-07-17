namespace Northwind.Web.Models;

using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

[Resource]
public class Employee : Identifiable<int>
{
  //[NotMapped]
  //public int Id { get; set; }
  [Attr]
  public string FirstName { get; set; }
  [Attr]
  public string LastName { get; set; }
}