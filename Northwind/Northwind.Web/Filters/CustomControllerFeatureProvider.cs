namespace Northwind.Web.Filters;

using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

public class CustomControllerFeatureProvider : ControllerFeatureProvider
{
  protected override bool IsController(TypeInfo typeInfo)
  {
    // Get the custom attributes you want to add to the controllers.
    var customAttribute = new MyAuthorizeAttribute();

    // Get the existing attributes.
    var existingAttributes = typeInfo.GetCustomAttributes().ToList();

    // Add the custom attribute to the existing attributes.
    existingAttributes.Add(customAttribute);

    // Set the new attributes array.
    var attributesArray = existingAttributes.ToArray();
    
    //typeInfo.SetCustomAttribute(attributesArray);    
    
    // Add [Authorize] attribute to each controller type.
    if (typeof(ControllerBase).IsAssignableFrom(typeInfo))
    {
      return true;
    }

    return base.IsController(typeInfo);
  }
}
