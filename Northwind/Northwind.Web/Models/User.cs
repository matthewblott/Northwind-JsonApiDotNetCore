namespace Northwind.Web.Models;

public class User
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Password { get; set; }
  public string RefreshToken { get; set; }
  public IList<Group> Groups { get; set; }

}