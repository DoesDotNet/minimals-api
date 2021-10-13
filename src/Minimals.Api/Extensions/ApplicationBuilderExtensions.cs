namespace Minimals.Api;

public static class ApplicationBuilderExtensions
{

    public static IApplicationBuilder UseSwaggerEndpoints(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    public static IEndpointRouteBuilder UseEndpointModule<TModule>(this IEndpointRouteBuilder routeBuilder)
        where TModule : IEndpointModule
    {
        var module = Activator.CreateInstance(typeof(TModule)) as IEndpointModule;
        if (module == null)
            throw new InvalidOperationException($"{typeof(TModule).Name} does not implement interface IEndpointModule");

        module.Configure(routeBuilder);

        return routeBuilder;
    }
}