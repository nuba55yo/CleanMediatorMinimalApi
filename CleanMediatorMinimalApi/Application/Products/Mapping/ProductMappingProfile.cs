using AutoMapper;
using CleanMediatorMinimalApi.Application.Products.Commands;
using CleanMediatorMinimalApi.Application.Products.DTOs;
using CleanMediatorMinimalApi.Domain.Entities;

namespace CleanMediatorMinimalApi.Application.Products.Mapping;
public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<CreateProduct, Product>();
        CreateMap<Product, ProductDto>();
    }
}