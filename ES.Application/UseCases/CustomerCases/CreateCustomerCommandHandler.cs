using ES.Application.Commands.CustomerCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Application.SeviceProvider;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.CustomerCases
{
    internal class CreateCustomerCommandHandler : IHandler<CreateCustomerCommand, Guid>
    {
        private readonly IRepository<Customer> _customersRepository;
        public CreateCustomerCommandHandler(IRepository<Customer> customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<Guid> HandleAsync(CreateCustomerCommand command, CancellationToken cancellation)
        {
            
            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                Phone = command.Phone,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Address = new Address()
                {
                    Country = command.Country,
                    City = command.City,
                    Street = command.Street,
                    HouseNumber = command.HouseNumber,
                    FlatNumber = command.FlatNumber,
                }
            };

            _customersRepository.Add(customer);

            return customer.Id;

        }
    }
}
