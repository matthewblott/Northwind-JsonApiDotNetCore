namespace Northwind.Web.Models;

using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

[Resource]
public class Category : Identifiable<int>
{
  [Attr]
  public string CategoryName { get; set; }
  [Attr]
  public string Description { get; set; }
}