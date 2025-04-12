using FastEndpoints;

namespace FastMinimalApi
{
    public class HelloEndpoint : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("/hello2");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendAsync("Hello World!");
        }
    }
}
