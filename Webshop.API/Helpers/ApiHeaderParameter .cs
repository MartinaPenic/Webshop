using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Webshop.API.Filters;

namespace Webshop.API.Authentication
{
    public class ApiHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = ApiConstants.ApiKeyHeaderName,
                Required = true,
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("3fc8669ae61945b9acebde2c40d49f3b")
                }
            });
        }
    }
}