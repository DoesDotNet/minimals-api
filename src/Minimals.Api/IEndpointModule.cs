namespace Minimals.Api;

public interface IEndpointModule
{
    void Configure(IEndpointRouteBuilder routeBuilder);
}