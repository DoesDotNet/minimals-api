using Minimals.Api.Customers;
using Minimals.Api.Employees;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Minimals");

builder.Services
    .AddMinimalsDbContext(connectionString)
    .AddSwagger();

await using WebApplication app = builder.Build();
app.UseSwaggerEndpoints();
app.UseEndpointModule<EmployeeEndpointModule>()
    .UseEndpointModule<CustomersEndpointModule>();

await app.RunAsync();
