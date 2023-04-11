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
    internal class UpdateOrderCommandHandler : IHandler<UpdateOrderCommand>
    {
        private readonly IRepository<Order> _orderRepository;
        public UpdateOrderCommandHandler(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task HandleAsync(UpdateOrderCommand command, CancellationToken cancellation)
        {
            var order = await _orderRepository.GetByIdAsync(command.OrderId);
            if(order is null)
            {
                throw new ApplicationException("Order not exist");
            }
            var oldOrderCount = order.Count;
            var oldOrderCost = order.Cost;

            var isChanged = false;

            if(command.Count != 0 && command.Count != order.Count)
            {
                order.Count = command.Count;

                order.Cost = command.Count * order.Product.Price;
                order.Cart.TotalCost -= oldOrderCost;
                order.Cart.TotalCost += order.Cost;

                order.Cart.TotalCount -= oldOrderCount;
                order.Cart.TotalCount += order.Count;

                order.CreateDate = command.CreateDate;

                isChanged = true;
            }

            if (isChanged)
            {
                await _orderRepository.UpdateAsync(order);
            }

        }
    }
}
