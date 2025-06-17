using Asp.Versioning.Builder;

namespace CleanMediatorMinimalApi.Presentation.Shared;
public interface IEndpointDefinition
{
    void RegisterEndpoints(WebApplication app, ApiVersionSet apiVersionSet);
}