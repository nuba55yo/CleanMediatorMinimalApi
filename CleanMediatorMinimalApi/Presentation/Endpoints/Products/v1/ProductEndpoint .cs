using CleanMediatorMinimalApi.Application.Products.DTOs;
using CleanMediatorMinimalApi.Presentation.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning.Builder;
using CleanMediatorMinimalApi.Application.Products.Commands;


namespace CleanMediatorMinimalApi.Presentation.Endpoints.Products.v1;
public class ProductEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app, ApiVersionSet apiVersionSet)
    {
        var group = app.MapGroup("api/v{version:apiVersion}/products")
                       .WithTags("Products")
                       .WithApiVersionSet(apiVersionSet)
                       .HasApiVersion(1);

        group.MapPost("/create", CreateProductAsync);
        group.MapPost("/getall", GetAllProductsAsync);
        group.MapPost("/getbyid", GetProductByIdAsync);
        group.MapPost("/update", UpdateProductAsync);
        group.MapPost("/delete", DeleteProductAsync);
    }

    private static async Task<IResult> CreateProductAsync(
        [FromBody] CreateProduct command,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        return Results.Created($"/products/{((ProductDto)result).Id}", result);
    }

    private static async Task<IResult> GetAllProductsAsync(
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetAllProducts(), cancellationToken);
        return Results.Ok(result);
    }

    private static async Task<IResult> GetProductByIdAsync(
        [FromBody] GetProductById query,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(query, cancellationToken);
        return result is not null ? Results.Ok(result) : Results.NotFound();
    }

    private static async Task<IResult> UpdateProductAsync(
        [FromBody] UpdateProduct command,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        return result is not null ? Results.Ok(result) : Results.NotFound();
    }

    private static async Task<IResult> DeleteProductAsync(
        [FromBody] DeleteProduct command,
        [FromServices] ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        return Results.Ok(result);
    }
}
