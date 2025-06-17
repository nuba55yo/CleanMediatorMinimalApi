using System.Reflection;
using CleanMediatorMinimalApi.Application.Products.Handlers;
using CleanMediatorMinimalApi.Application.Products.Interfaces;
using CleanMediatorMinimalApi.Application.Products.Mapping;
using CleanMediatorMinimalApi.Application.Products.Validators;
using CleanMediatorMinimalApi.Infrastucture.Repositories.MemoryCache;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanMediatorMinimalApi.Infrastructure.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // 🔧 Register Repositories
        services.AddScoped<IProductRepository, ProductMemoryCacheRepository>();

        // 🔧 MemoryCache
        services.AddMemoryCache();

        // 🔧 MediatR
        services.AddMediatR(typeof(CreateProductHandler).Assembly);
        services.AddMediatR(typeof(DeleteProductHandler).Assembly);
        services.AddMediatR(typeof(GetAllProductsHandler).Assembly);
        services.AddMediatR(typeof(GetProductByIdHandler).Assembly);
        services.AddMediatR(typeof(UpdateProductHandler).Assembly);


        // 🔧 AutoMapper
        services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);

        // 🔧 Validators
        services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();


        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();


        return services;
    }
}