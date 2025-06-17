using CleanMediatorMinimalApi.Domain.Entities;
using MediatR;

namespace CleanMediatorMinimalApi.Application.Products.Commands;
public record GetProductById(Guid Id) : IRequest<object>;
