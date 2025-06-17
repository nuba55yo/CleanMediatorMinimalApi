using CleanMediatorMinimalApi.Domain.Entities;
using MediatR;

namespace CleanMediatorMinimalApi.Application.Products.Commands;
public record DeleteProduct(Guid Id) : IRequest<object>;