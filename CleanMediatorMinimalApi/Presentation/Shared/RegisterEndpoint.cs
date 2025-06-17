using Asp.Versioning;
using Asp.Versioning.Builder;


namespace CleanMediatorMinimalApi.Presentation.Shared;
public static class RegisterEndpoint
{
    public static void Definitions(this WebApplication app)
    {
        var apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();

        var endpointDefinitions = typeof(Program).Assembly
            .GetTypes()
            .Where(t => typeof(IEndpointDefinition).IsAssignableFrom(t) && !t.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var def in endpointDefinitions)
        {
            def.RegisterEndpoints(app, apiVersionSet);
        }
    }
}
