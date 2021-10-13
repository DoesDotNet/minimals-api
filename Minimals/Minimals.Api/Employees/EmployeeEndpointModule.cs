namespace Minimals.Api.Employees;

public class EmployeeEndpointModule : IEndpointModule
{
    public void Configure(IEndpointRouteBuilder routeBuilder)
    {
        if (routeBuilder is null)
        {
            throw new ArgumentNullException(nameof(routeBuilder));
        }

        routeBuilder.MapGet("/employees/", async ([FromServices] MinimalsDbContext db) => await db.Employees.ToListAsync());
        routeBuilder.MapGet("/employees/{id}", ([FromServices] MinimalsDbContext db, int id) =>
        {
            var employee = db.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if (employee == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(employee);
        });

        routeBuilder.MapPost("/employees/", async ([FromServices] MinimalsDbContext db, Employee employee) =>
        {
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return Results.StatusCode(201);
        });

        routeBuilder.MapPut("/employees/{id}", async ([FromServices] MinimalsDbContext db, int id, Employee employee) =>
        {
            if (id != employee.EmployeeId)
            {
                return Results.BadRequest();
            }

            if (!db.Employees.Any(x => x.EmployeeId == employee.EmployeeId))
            {
                return Results.NotFound();
            }

            db.Entry(employee).State = EntityState.Modified;

            await db.SaveChangesAsync();

            return Results.Accepted();
        });

        routeBuilder.MapDelete("/employees/{id}", async (MinimalsDbContext db, int id) =>
        {
            var employee = await db.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (employee == null)
            {
                return Results.NotFound();
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return Results.Ok();
        });
    }
}
