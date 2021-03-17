using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

using Microsoft.OpenApi.Models;

namespace todo_api.Swagger
{
    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the
    /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _provider;
        readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        /// <param name="config">Thw set of key/value application configuration properties.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IConfiguration config)
        {
            _provider = provider;
            _config = config;
        }

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // Add a swagger document for each discovered API version
            // Note: you might choose to skip or document deprecated API versions differently
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, _config));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description, IConfiguration config)
        {
            var title = config["Service:Title"];
            var info = new OpenApiInfo()
            {
                Title = $"{title} {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = config["Service:Description"],
                Contact = new OpenApiContact()
                {
                    Name = config["Service:Contact:Name"],
                    Email = config["Service:Contact:Email"]
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}