using Bogus;
using Domain.Models;

namespace Infrastructure.Fakers;

// dotnet add package Bogus
public sealed class ProductFaker : Faker<Product>
{
    public ProductFaker()
    {
        UseSeed(1);
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
        RuleFor(p => p.Price, f => f.Finance.Amount(1, 1000));
        RuleFor(p => p.Code, f => f.Random.Replace("???-#####").ToUpper());
        RuleFor(p => p.Color, f => f.PickRandom("Red", "Green", "Blue"));
        RuleFor(p => p.ExpiryDate, f => f.Date.FutureDateOnly(2));
        RuleFor(p => p.ImageUrl, (f,p) => $"https://picsum.photos/seed/{p.Id}/300/400");
    }
}