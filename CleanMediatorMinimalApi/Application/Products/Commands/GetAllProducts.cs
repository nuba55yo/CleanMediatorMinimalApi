using MediatR;

namespace CleanMediatorMinimalApi.Application.Products.Commands;
public record GetAllProducts() : IRequest<object>;