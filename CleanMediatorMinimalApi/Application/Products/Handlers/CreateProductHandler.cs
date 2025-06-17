using System.Security.Claims;
using AutoMapper;
using CleanMediatorMinimalApi.Application.Products.Commands;
using CleanMediatorMinimalApi.Application.Products.DTOs;
using CleanMediatorMinimalApi.Application.Products.Interfaces;
using CleanMediatorMinimalApi.Domain.Entities;
using MediatR;

namespace CleanMediatorMinimalApi.Application.Products.Handlers;
public class CreateProductHandler : IRequestHandler<CreateProduct, object>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateProductHandler> _logger;

    public CreateProductHandler(IProductRepository repo, IMapper mapper, ILogger<CreateProductHandler> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<object> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handling CreateProduct: {@Request}", request);
            var product = new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price };
            await _repo.AddAsync(product,cancellationToken);
            _logger.LogInformation("Product created: {@Product}", product);
            return _mapper.Map<ProductDto>(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception in CreateProductHandler");
            throw;
        }
    }
}