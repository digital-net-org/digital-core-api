using Microsoft.OpenApi.Models;
using SafariDigital.Services.JwtService;

namespace SafariDigital.Api.Builders.Injectors;

public static class SwaggerInjector
{
    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(opts =>
        {
            opts.SwaggerDoc("v1", new OpenApiInfo { Title = "SafariDigital", Version = "v1.0" });
            opts.AddJwtSwagger();
        });
        return builder;
    }
}