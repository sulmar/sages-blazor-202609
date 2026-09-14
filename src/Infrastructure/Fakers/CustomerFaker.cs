using Bogus;
using Domain.Models;

namespace Infrastructure.Fakers;

// dotnet add package Bogus
public sealed class CustomerFaker : Faker<Customer>
{
    public CustomerFaker()
    {
        UseSeed(1);
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Name, f => f.Company.CompanyName());
        RuleFor(p => p.Email, f => f.Internet.Email());
        RuleFor(p => p.IsDeleted, f => f.Random.Bool(0.3f)); // Adjusted probability distribution: 30% chance of being true
    }
}
