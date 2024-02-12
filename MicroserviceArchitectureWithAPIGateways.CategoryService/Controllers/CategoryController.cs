using MicroserviceArchitectureWithAPIGateways.CategoryService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitectureWithAPIGateways.CategoryService.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private static readonly string[] CategoryNames= new[]
    {
        "Pudding", "Pie", "Pizza", "Rolls", "Sandwiches", "Sushi"
    };

    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    [HttpGet("get-all")]
    public IEnumerable<Category> Get()
    {
        _logger.LogInformation("Get all categories");
        return Enumerable.Range(1, 5).Select(index => new Category
            {
                Id = Guid.NewGuid(),
                Name = CategoryNames[Random.Shared.Next(CategoryNames.Length)]
            })
            .ToArray();
    }
}