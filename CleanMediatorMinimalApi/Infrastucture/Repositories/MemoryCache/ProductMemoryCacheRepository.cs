using CleanMediatorMinimalApi.Application.Products.Interfaces;
using CleanMediatorMinimalApi.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CleanMediatorMinimalApi.Infrastucture.Repositories.MemoryCache;

public class ProductMemoryCacheRepository : IProductRepository
{
    private const string CacheKey = "products";
    private readonly IMemoryCache _cache;

    public ProductMemoryCacheRepository(IMemoryCache cache)
    {
        _cache = cache;
        _cache.GetOrCreate(CacheKey, entry => new List<Product>());
    }

    private List<Product> Products => _cache.Get<List<Product>>(CacheKey)!;

    public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Products.AsEnumerable());
    }


    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(Products.FirstOrDefault(p => p.Id == id));
    }


    public Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        Products.Add(product);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        var index = Products.FindIndex(p => p.Id == product.Id);
        if (index >= 0) Products[index] = product;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        Products.RemoveAll(p => p.Id == id);
        return Task.CompletedTask;
    }
}