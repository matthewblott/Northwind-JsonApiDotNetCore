namespace Northwind.Web.Filters;

using Microsoft.AspNetCore.Mvc;

public class MyAuthorizeAttribute : TypeFilterAttribute
{
  public MyAuthorizeAttribute() : base(typeof(MyAuthorizationFilter))
  {
  }
}