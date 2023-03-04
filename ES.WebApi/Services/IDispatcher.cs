namespace ES.WebApi.Services
{
    public interface IDispatcher
    {
        Task DispatchAsync<TMessage>(TMessage request, CancellationToken cancellation = default);
        Task<TResult> DispatchAsync<TRequest, TResult>(TRequest request, CancellationToken cancellation = default);
    }
}
