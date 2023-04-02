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
        private readonly IAuthCustomerProvider _authCustomerProvider;
        public CreatePaymentCommandHandler(IRepository<Cart> cartRepository, IAuthCustomerProvider authCustomerProvider)
        {
            _cartRepository = cartRepository;
            _authCustomerProvider = authCustomerProvider;
        }

        public async Task HandleAsync(CreatePaymentCommand command, CancellationToken cancellation)
        {
            var cart = await _cartRepository.GetByIdAsync(command.CartId);
            var authCustomer = _authCustomerProvider.GetAuthCustomer();
            var isChanged = false;

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
