namespace Minimals.Api;

using Minimals.Api.Employees;
using Minimals.Api.Customers;

public class MinimalsDbContext : DbContext
{

    public MinimalsDbContext(DbContextOptions<MinimalsDbContext> options)
        : base(options)
    {

    }

    public DbSet<Employee> Employees {  get; set; }
    public DbSet<Customer> Customers { get; set; }
}
