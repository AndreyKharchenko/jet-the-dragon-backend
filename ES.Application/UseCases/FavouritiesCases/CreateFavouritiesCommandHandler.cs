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
    internal class CreateFavouritiesCommandHandler : IHandler<CreateFavouritiesCommand, Guid>
    {
        private readonly IRepository<Favourities> _favouritiesRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;

        public CreateFavouritiesCommandHandler(IRepository<Favourities> favouritiesRepository, IRepository<Customer> customerRepository, IRepository<Product> productRepository)
        {
            _favouritiesRepository = favouritiesRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<Guid> HandleAsync(CreateFavouritiesCommand command, CancellationToken cancellation)
        {
            var customer = await _customerRepository.GetByIdAsync(command.CustomerId);
            if (customer is null)
            {
                throw new ApplicationException("Customer not exist");
            }

            var product = await _productRepository.GetByIdAsync(command.ProductId);
            if (product is null)
            {
                throw new ApplicationException("Product not exist");
            }

            var favouritie = new Favourities()
            {
                Id = Guid.NewGuid(),
                Customer = customer,
                CustomerId = customer.Id,
                Product = product,
                ProductId = product.Id,
            };

            _favouritiesRepository.Add(favouritie);

            return favouritie.Id;

        }
    }
}
