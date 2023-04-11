using ES.Application.Commands.FavouritiesCommands;
using ES.Application.Commands.ProductCommands;
using ES.Application.Infrastructure;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.FavouritiesCases
{
    internal class UpdateFavouriteCommandHandler : IHandler<UpdateFavouriteCommand>
    {
        private readonly IRepository<Favourities> _favouritiesRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;

        public UpdateFavouriteCommandHandler(IRepository<Favourities> favouritiesRepository, IRepository<Customer> customerRepository, IRepository<Product> productRepository)
        {
            _favouritiesRepository = favouritiesRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task HandleAsync(UpdateFavouriteCommand command, CancellationToken cancellation)
        {

            var favourite = await _favouritiesRepository.GetByIdAsync(command.FavouriteId);
            var isChanged = false;

            if (command.CustomerId is not null)
            {
                var customer = await _customerRepository.GetByIdAsync(command.CustomerId.Value);
                if (customer is null)
                {
                    throw new ApplicationException("Customer not exist");
                }

                favourite.Customer = customer;
                favourite.CustomerId = command.CustomerId.Value;
            }

            if (command.ProductId is not null)
            {
                var product = await _productRepository.GetByIdAsync(command.ProductId.Value);
                if (product is null)
                {
                    throw new ApplicationException("Product not exist");
                }

                favourite.Product = product;
                favourite.ProductId = command.ProductId.Value;
            }

            if (isChanged)
            {
                await _favouritiesRepository.UpdateAsync(favourite);
            }
        }
    }
}
