using AutoMapper;
using CleanMediatorMinimalApi.Application.Products.Commands;
using CleanMediatorMinimalApi.Application.Products.DTOs;
using CleanMediatorMinimalApi.Application.Products.Interfaces;
using MediatR;

namespace CleanMediatorMinimalApi.Application.Products.Handlers;
public class UpdateProductHandler : IRequestHandler<UpdateProduct, object>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateProductHandler> _logger;

    public UpdateProductHandler(IProductRepository repo, IMapper mapper, ILogger<UpdateProductHandler> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<object> Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling UpdateProduct: {@Request}", request);
        var queryProductById = await _repo.GetByIdAsync(request.Id, cancellationToken);
        if (queryProductById == null)
        {
            _logger.LogWarning("Product not found for update: {Id}", request.Id);
            return null!;
        }
        queryProductById.Name = request.Name;
        queryProductById.Price = request.Price;
        await _repo.UpdateAsync(queryProductById, cancellationToken);
        _logger.LogInformation("Product updated: {@Product}", queryProductById);
        return _mapper.Map<ProductDto>(queryProductById);
    }
}