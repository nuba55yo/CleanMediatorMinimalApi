using AutoMapper;
using CleanMediatorMinimalApi.Application.Products.Commands;
using CleanMediatorMinimalApi.Application.Products.DTOs;
using CleanMediatorMinimalApi.Application.Products.Interfaces;
using MediatR;

namespace CleanMediatorMinimalApi.Application.Products.Handlers;
public class GetAllProductsHandler : IRequestHandler<GetAllProducts, object>
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllProductsHandler> _logger;

    public GetAllProductsHandler(IProductRepository repo, IMapper mapper, ILogger<GetAllProductsHandler> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<object> Handle(GetAllProducts request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling GetAllProducts");
        var result = await _repo.GetAllAsync(cancellationToken);
        _logger.LogInformation("Products retrieved: {Count}", result.Count());
        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }
}