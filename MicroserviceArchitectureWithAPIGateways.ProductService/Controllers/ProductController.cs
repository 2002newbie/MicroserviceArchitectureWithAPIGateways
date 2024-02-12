using MicroserviceArchitectureWithAPIGateways.ProductService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitectureWithAPIGateways.ProductService.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private static readonly string[] CategoryNames= new[]
    {
        "Pudding", "Pie", "Pizza", "Rolls", "Sandwiches", "Sushi"
    };

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet("get-all")]
    public IEnumerable<Product> Get()
    {
        _logger.LogInformation("Get all products");
        return Enumerable.Range(1, 5).Select(index => new Product
            {
                Id = Guid.NewGuid(),
                Name = CategoryNames[Random.Shared.Next(CategoryNames.Length)],
                CategoryId = Guid.NewGuid()
            })
            .ToArray();
    }
}