using AutoMapper;
using CleanMediatorMinimalApi.Application.Products.Commands;
using CleanMediatorMinimalApi.Application.Products.DTOs;
using CleanMediatorMinimalApi.Application.Products.Interfaces;
using CleanMediatorMinimalApi.Domain.Entities;
using MediatR;

namespace CleanMediatorMinimalApi.Application.Products.Handlers;

public class DeleteProductHandler : IRequestHandler<DeleteProduct, object>
{
    private readonly IProductRepository _repo;
    private readonly ILogger<DeleteProductHandler> _logger;

    public DeleteProductHandler(IProductRepository repo, ILogger<DeleteProductHandler> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<object> Handle(DeleteProduct request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling DeleteProduct: {Id}", request.Id);
        var existing = await _repo.GetByIdAsync(request.Id, cancellationToken);
        if (existing == null)
        {
            _logger.LogWarning("Product not found for delete: {Id}", request.Id);
            return false;
        }
        await _repo.DeleteAsync(request.Id,cancellationToken);
        _logger.LogInformation("Product deleted: {Id}", request.Id);
        return true;
    }
}

