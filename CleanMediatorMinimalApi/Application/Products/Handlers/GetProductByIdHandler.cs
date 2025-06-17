using AutoMapper;
using CleanMediatorMinimalApi.Application.Products.Commands;
using CleanMediatorMinimalApi.Application.Products.DTOs;
using CleanMediatorMinimalApi.Application.Products.Interfaces;
using MediatR;

namespace CleanMediatorMinimalApi.Application.Products.Handlers;
public class GetProductByIdHandler : IRequestHandler<GetProductById, object>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<GetProductByIdHandler> _logger;

    public GetProductByIdHandler(IProductRepository repo, IMapper mapper, ILogger<GetProductByIdHandler> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<object> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling GetProductById: {Id}", request.Id);
        var result = await _repo.GetByIdAsync(request.Id, cancellationToken);
        if (result == null)
        {
            _logger.LogWarning("Product not found: {Id}", request.Id);
            return null!;
        }
        _logger.LogInformation("Product retrieved: {@Product}", result);
        return _mapper.Map<ProductDto>(result);
    }
}
