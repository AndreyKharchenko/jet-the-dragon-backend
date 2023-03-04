using ES.Application.Commands.CategoryCommands;
using ES.Application.Commands.OrderCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Application.SeviceProvider;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.OrderCases
{
    internal class CreateOrderCommandHandler : IHandler<CreateOrderCommand, Guid>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Product> _productRepository;
        public CreateOrderCommandHandler(IRepository<Order> orderRepository, IRepository<Cart> cartRepository, IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<Guid> HandleAsync(CreateOrderCommand command, CancellationToken cancellation)
        {
            var cart = await _cartRepository.GetByIdAsync(command.CartId);
            if(cart is null)
            {
                throw new ApplicationException("Cart not exist");
            }
            var product = await _productRepository.GetByIdAsync(command.ProductId);
            if(product is null)
            {
                throw new ApplicationException("Product not exist");
            }
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                Cart = cart,
                CartId = cart.Id,
                Product = product,
                ProductId= product.Id,
                Count = command.Count,
                Cost = command.Count * product.Price
            };

            cart.TotalCost += order.Cost;
            cart.TotalCount += order.Count;

            _orderRepository.Add(order);

            return order.Id;

        }
    }
}
