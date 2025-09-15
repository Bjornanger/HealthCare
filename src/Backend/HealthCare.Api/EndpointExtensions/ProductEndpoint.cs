using HealthCare.Application.DataTransferObjects.Product;
using HealthCare.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.EndpointExtensions;

public static class ProductEndpoint
{
    public static IEndpointRouteBuilder MapProductEndpointExtensions(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/products");

        group.MapGet("/", GetAllProducts);
        group.MapGet("/{id:guid}", GetProductById);
        group.MapPost("/", AddProduct);
        group.MapPut("/{id}", UpdateProduct);
        group.MapDelete("/{id}", DeleteProduct);
        group.MapPut("/{id}/quantity", UpdateProductQuantity);

        return app;
    }
  
    private static async Task<IResult> GetAllProducts(IProductService productService)
    {
        var productList = await productService.GetAllAsync();

        if (productList is null || !productList.Any())
        {
            productList = new List<ProductDto>();
        }

        return Results.Ok(productList);

    }
    private static async Task<IResult> GetProductById(IProductService productService, Guid id)
    {
        var productToFind = await productService.GetByIdAsync(id);

        if (productToFind == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(productToFind);

    }
    private static async Task<IResult> AddProduct(IProductService productService, CreateProductDto createProductDto)
    {
        var newProduct = await productService.AddAsync(createProductDto);

        if (newProduct == null)
        {
            return Results.BadRequest();
        }

        return Results.Ok(newProduct);
    }
    private static async Task<IResult> UpdateProduct(IProductService productService, ProductDto productDto, Guid id)
    {
        var successObject = await productService.UpdateAsync(productDto, id);

        if (!successObject)
        {
            return Results.BadRequest();
        }
        return Results.Ok();
    }
    private static async Task<IResult> DeleteProduct(IProductService productService, Guid id)
    {
        var successObject = await productService.DeleteAsync(id);

        if (!successObject)
        {
            return Results.BadRequest();
        }

        return Results.Ok();
    }
    private static async Task<IResult> UpdateProductQuantity(IProductService productService, Guid id, [FromBody] int amountToChange)
    {
        var successObject = await productService.UpdateQuantity(id, amountToChange);

        if (!successObject)
        {
            return Results.BadRequest();
        }

        return Results.Ok();
    }
}