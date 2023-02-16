using System.Net;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DotnetReactVerticalSlice.Swagger;

public static class SwaggerStartup
{
    public static void Register(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt => opt.OperationFilter<GlobalErrorHandlingResponseTypeFilter>());
        services.AddSingleton<IApiBuilder, SwaggerApiBuilder>();
    }

    private class GlobalErrorHandlingResponseTypeFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            
            if (!context.SchemaRepository.Schemas.TryGetValue(nameof(ErrorResult), out OpenApiSchema? schema))
            {
                schema = context.SchemaGenerator.GenerateSchema(typeof(ErrorResult), context.SchemaRepository);
            }
            
            operation.Responses.Add("400", new OpenApiResponse()
            {
                Description = "Bad Request",
                Reference = schema.Reference,
                Content = new Dictionary<string, OpenApiMediaType>()
                {
                    {"application/json", new OpenApiMediaType()
                    {
                        Example = schema.Example,
                        Schema = schema
                    }}
                }
            });
            operation.Responses.Add("500", new OpenApiResponse()
            {
                Description = "Internal Server Error",
                Reference = schema.Reference,
                Content = new Dictionary<string, OpenApiMediaType>()
                {
                    {"application/json", new OpenApiMediaType()
                    {
                        Example = schema.Example,
                        Schema = schema
                    }}
                }
            });

        }
    }
}