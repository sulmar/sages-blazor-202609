namespace Domain.Models;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? Color { get; set; }
    public DateOnly? ExpiryDate { get; set; }
    public string? ImageUrl { get; set; }
}