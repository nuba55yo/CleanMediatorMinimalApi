using CleanMediatorMinimalApi.Application.Products.Commands;
using CleanMediatorMinimalApi.Application.Products.Interfaces;
using CleanMediatorMinimalApi.Application.Products.Mapping;
using CleanMediatorMinimalApi.Application.Products.Validators;
using CleanMediatorMinimalApi.Infrastucture.Repositories.MemoryCache;
using FluentValidation;
using MediatR;
using Serilog;
using Asp.Versioning;
using Asp.Versioning.Builder;
using CleanMediatorMinimalApi.Presentation.Endpoints.Products.v1;
using CleanMediatorMinimalApi.Presentation.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});

// Register services
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IProductRepository, ProductMemoryCacheRepository>();

builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(typeof(CreateProduct).Assembly);
builder.Services.AddMediatR(typeof(DeleteProduct).Assembly);
builder.Services.AddMediatR(typeof(GetAllProducts).Assembly);
builder.Services.AddMediatR(typeof(GetProductById).Assembly);
builder.Services.AddMediatR(typeof(UpdateProduct).Assembly);

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); // /api/v{version}/xxx
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();




app.Definitions(); // จะดึงทุก Endpoint ที่ implement IEndpointDefinition

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
