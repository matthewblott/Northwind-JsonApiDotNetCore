namespace Northwind.Web.Definitions;

using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Queries.Expressions;
using JsonApiDotNetCore.Resources;
using Models;

public class CustomerDefinition : JsonApiResourceDefinition<Customer, string>
{
  public CustomerDefinition(IResourceGraph resourceGraph) : base(resourceGraph)
  { 
    
  }

  public override void OnSerialize(Customer resource)
  {
    var name = resource.CompanyName;
    
    Console.WriteLine(name);

    resource.CompanyName = "one two buckle shoe";
    
    base.OnSerialize(resource);
  }

  public override SparseFieldSetExpression? OnApplySparseFieldSet(SparseFieldSetExpression? existingSparseFieldSet)
  {
    var fieldSet = existingSparseFieldSet;

    if (fieldSet != null)
    {
      var numberOfFields =  fieldSet.Fields.Count;
    
      Console.WriteLine(numberOfFields);
      
    }
    
    return base.OnApplySparseFieldSet(existingSparseFieldSet);
  }
}