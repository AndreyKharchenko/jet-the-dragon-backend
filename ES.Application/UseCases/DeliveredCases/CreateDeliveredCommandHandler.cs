using ES.Application.Commands.DeliveredCommands;
using ES.Application.Commands.PaymentCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.DeliveredCases
{
    internal class CreateDeliveredCommandHandler : IHandler<CreateDeliveredCommand>
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;
        public CreateDeliveredCommandHandler(IRepository<Cart> cartRepository, IRepository<Order> orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        public async Task HandleAsync(CreateDeliveredCommand command, CancellationToken cancellation)
        {
            var cart = await _cartRepository.GetByIdAsync(command.CartId);
            var orders = await _orderRepository.GetByExpressionAsync(x => x.CartId == command.CartId);
            
            var isChanged = false;


            if (command.Delivered)
            {
                cart.Status = CartStatus.Delivered;
                isChanged = true;
            }

            if (isChanged)
            {
                await _cartRepository.UpdateAsync(cart);
            }


        }
    }
}
