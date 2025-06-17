using CleanMediatorMinimalApi.Domain.Entities;
using MediatR;

namespace CleanMediatorMinimalApi.Application.Products.Commands;
public record UpdateProduct(Guid Id, string Name, decimal Price) : IRequest<object>;