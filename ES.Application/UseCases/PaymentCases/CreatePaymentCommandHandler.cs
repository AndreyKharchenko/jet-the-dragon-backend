using ES.Application.Commands.CartCommands;
using ES.Application.Commands.PaymentCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.CartCases
{
    internal class CreatePaymentCommandHandler : IHandler<CreatePaymentCommand>
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IAuthCustomerProvider _authCustomerProvider;
        public CreatePaymentCommandHandler(IRepository<Cart> cartRepository, IAuthCustomerProvider authCustomerProvider, IRepository<Order> orderRepository)
        {
            _cartRepository = cartRepository;
            _authCustomerProvider = authCustomerProvider;
            _orderRepository = orderRepository;
        }

        public async Task HandleAsync(CreatePaymentCommand command, CancellationToken cancellation)
        {
            var cart = await _cartRepository.GetByIdAsync(command.CartId);
            var orders = await _orderRepository.GetByExpressionAsync(x => x.CartId == command.CartId);
            var authCustomer = _authCustomerProvider.GetAuthCustomer();
            var isChanged = false;

            foreach(var order in orders)
            {
                var value = order.Product.Count - order.Count;

                if (value < 0)
                {
                    throw new ApplicationException("Insufficient number of products");
                }

                order.Product.Count = value;
                isChanged = true;

            }

            if(cart.CustomerId != authCustomer.Id)
            {
                throw new ApplicationException("Not allowed");
            }

            if(command.Payment)
            {
                cart.Status = CartStatus.ConfirmPay;
                isChanged = true;
            }

            if (isChanged)
            {
                await _cartRepository.UpdateAsync(cart);
            }

            
        }
    }
}
