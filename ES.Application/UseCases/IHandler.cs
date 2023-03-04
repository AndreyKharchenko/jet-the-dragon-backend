using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases
{
    public interface IHandler<in TRequest>
    {
        Task HandleAsync(TRequest request, CancellationToken cancellation);
    }

    public interface IHandler<in TRequest, TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellation);
    }
}
