using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
public class ViewModelController : Controller
{
    // Index method with id parameter
    public IActionResult Client(int id)
    {
            // Handle the case where id is present
            var customer = GetCustomerById(id);

            if (customer == null)
            {
                return Content("Error 404: Customer not found");
            }

            return View(customer);
    }

    // Index method without id parameter
    public IActionResult Index()
    {
        // Handle the case where no id is present
        var viewModel = GetViewModel();
        return View(viewModel);
    }

    private Customer GetCustomerById(int customerId)
    {
        // Your logic to retrieve a customer by id goes here
        List<Customer> customers = new List<Customer>()
        {
            new Customer{Name="test1", Id=1},
            new Customer{Name="test2", Id=2},
            new Customer{Name="test3", Id=3}
        };

        return customers.FirstOrDefault(c => c.Id == customerId);
    }

    private ViewModel GetViewModel()
    {
        // Your logic to create a ViewModel goes here
        Movie movie = new Movie() { Name = "movie 1" };
        List<Customer> customers = new List<Customer>()
        {
            new Customer{Name="test1", Id=1},
            new Customer{Name="test2", Id=2},
            new Customer{Name="test3", Id=3}
        };

        return new ViewModel() { Movie = movie, Customers = customers };
    }
}
}
