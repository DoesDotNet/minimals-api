namespace Minimals.Api.Customers;
public class CustomersEndpointModule : IEndpointModule
{
    public void Configure(IEndpointRouteBuilder routeBuilder)
    {
        if (routeBuilder is null)
        {
            throw new ArgumentNullException(nameof(routeBuilder));
        }

        routeBuilder.MapGet("/customers/", async ([FromServices] MinimalsDbContext db, [FromQuery] int? page, [FromQuery] int? pageSize) =>
        {
            if(!page.HasValue)
                page = 1;

            if(!pageSize.HasValue)
                pageSize = 10;

            int skip = (page.Value - 1) * pageSize.Value;

            var customer =  await db.Customers.Skip(skip).Take(pageSize.Value).ToListAsync();

            return Results.Ok(customer);
        });
    }
}