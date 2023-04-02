using ES.Application.Commands.CartCommands;
using ES.Application.Commands.CategoryCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Application.SeviceProvider;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.CartCases
{
    internal class CreateCartCommandHandler : IHandler<CreateCartCommand, Guid>
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IAuthCustomerProvider _authCustomerProvider;
        public CreateCartCommandHandler(IRepository<Cart> cartRepository, IAuthCustomerProvider authCustomerProvider)
        {
            _cartRepository = cartRepository;
            _authCustomerProvider = authCustomerProvider;
        }

        public async Task<Guid> HandleAsync(CreateCartCommand command, CancellationToken cancellation)
        {
            var customer = _authCustomerProvider.GetAuthCustomer();
            if(customer is null)
            {
                throw new ApplicationException("Customer not exist");
            }
            var cart = (await _cartRepository.GetByExpressionAsync(x => x.CustomerId == customer.Id && x.Status == CartStatus.Created)).FirstOrDefault();

            if(cart is not null)
            {
                return cart.Id;
            }

            cart = new Cart()
            {
                Id = Guid.NewGuid(),
                Customer = customer,
                CustomerId = customer.Id,
                DeliveryType = command.DeliveryType,
                PaymentType = command.PaymentType,
                Comment = command.Comment,
                Status = CartStatus.Created,
                TotalCost = 0,
                TotalCount = 0,
            };

            _cartRepository.Add(cart);

            return cart.Id;

        }
    }
}
