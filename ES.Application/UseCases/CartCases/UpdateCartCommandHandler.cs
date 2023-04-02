using ES.Application.Commands.CartCommands;
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
    internal class UpdateCartCommandHandler : IHandler<UpdateCartCommand>
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IAuthCustomerProvider _authCustomerProvider;
        public UpdateCartCommandHandler(IRepository<Cart> cartRepository, IAuthCustomerProvider authCustomerProvider)
        {
            _cartRepository = cartRepository;
            _authCustomerProvider = authCustomerProvider;
        }

        public async Task HandleAsync(UpdateCartCommand command, CancellationToken cancellation)
        {
            var cart = await _cartRepository.GetByIdAsync(command.CartId);
            var authCustomer = _authCustomerProvider.GetAuthCustomer();
            var isChanged = false;

            if(cart.CustomerId != authCustomer.Id)
            {
                throw new ApplicationException("Not allowed");
            }

            if(command.DeliveryType is not null && command.DeliveryType != cart.DeliveryType)
            {
                cart.DeliveryType = command.DeliveryType;
                isChanged = true;
            }

            if (command.PaymentType is not null && command.PaymentType != cart.PaymentType)
            {
                cart.PaymentType = command.PaymentType;
                isChanged = true;
            }

            if (command.Comment is not null && command.Comment != cart.Comment)
            {
                cart.Comment = command.Comment;
                isChanged = true;
            }

            if (isChanged)
            {
                await _cartRepository.UpdateAsync(cart);
            }
        }
    }
}
