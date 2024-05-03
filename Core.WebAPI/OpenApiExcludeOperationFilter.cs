//using System.Reflection;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;

//namespace Core.WebAPI;

////https://dejanstojanovic.net/aspnet/2019/october/ignoring-properties-from-controller-action-model-in-swagger-using-jsonignore/
//public class OpenApiExcludeOperationFilter : IOperationFilter
//{
//    public void Apply(OpenApiOperation operation, OperationFilterContext context)
//    {
//        var excludedProperties = context.MethodInfo.GetParameters()
//            .Where(p => p.GetCustomAttribute<FromQueryAttribute>() != null)
//            .SelectMany(p => p.ParameterType.GetProperties()
//                .Where(prop => prop.GetCustomAttribute<OpenApiExcludeAttribute>() != null)
//            )
//            .Select(t => t.Name)
//            .ToList();

//        if (excludedProperties.Any())
//        {
//            operation.Parameters = operation.Parameters
//                .Where(p => p.In != ParameterLocation.Query || !excludedProperties.Contains(p.Name, StringComparer.InvariantCultureIgnoreCase))
//                .ToList();
//        }
//    }
//}
