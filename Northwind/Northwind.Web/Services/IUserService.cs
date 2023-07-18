namespace Northwind.Web.Services;

using Models;

public interface IUserService
{
  User GetByName(string name);
  void Add(User user);
  void Update(User user);
}