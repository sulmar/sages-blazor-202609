using Domain.Models;

namespace BlazorApp.Components.Pages.Customers
{
    public partial class List
    {
        private IEnumerable<Customer>? customers;

        // [Inject]
        // private CustomerFaker faker { get; set; }

        protected override async Task OnInitializedAsync()
        {
            customers = await Repository.GetAllAsync(); // Load customers from the repository                                
        }

    }
}