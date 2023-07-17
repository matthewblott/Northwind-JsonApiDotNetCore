using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Controllers;

using System.Text.Json;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class HelloController : ControllerBase
{
  private readonly NorthwindDbContext _context;

  public HelloController(NorthwindDbContext context)
  {
    _context = context;
  }

  public string Index() => "Hello";
  
  public string Customer()
  {
    var customer = _context.Customers.FirstOrDefault();

    return customer.CompanyName;
  }
  
}