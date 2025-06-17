using MediatR;
using CleanMediatorMinimalApi.Domain.Entities;

namespace CleanMediatorMinimalApi.Application.Products.Commands;

public record CreateProduct(string Name, decimal Price) : IRequest<object>;