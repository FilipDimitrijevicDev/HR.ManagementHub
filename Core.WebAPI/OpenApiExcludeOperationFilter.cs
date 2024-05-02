//namespace Core.WebAPI;

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
