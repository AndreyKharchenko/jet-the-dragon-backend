using ES.Application.Commands.OrderCommands;
using ES.Application.Infrastructure;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.OrderCases
{
    internal class DeleteOrderCommandHandler : IHandler<DeleteOrderCommand>
    {
        private readonly IRepository<Order> _orderRepository;
        public DeleteOrderCommandHandler(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task HandleAsync(DeleteOrderCommand command, CancellationToken cancellation)
        {
            var order = await _orderRepository.GetByIdAsync(command.OrderId);
            if (order is null)
            {
                throw new ApplicationException("Order not exist");
            }
            
            await _orderRepository.RemoveAsync(order);
            
        }
    }
}
