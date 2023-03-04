using ES.Application.UseCases;

namespace ES.WebApi.Services
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task DispatchAsync<TMessage>(TMessage message, CancellationToken cancellation = default(CancellationToken))
        {
            var handlers = _serviceProvider.GetServices<IHandler<TMessage>>();
            await Task.WhenAll(handlers.Select(handler => handler.HandleAsync(message, cancellation)));
        }

        public async Task<TResult> DispatchAsync<TRequest, TResult>(TRequest request, CancellationToken cancellation = default(CancellationToken))
        {
            var handler = _serviceProvider.GetRequiredService<IHandler<TRequest, TResult>>();
            return await handler.HandleAsync(request, cancellation);
        }
    }
}
