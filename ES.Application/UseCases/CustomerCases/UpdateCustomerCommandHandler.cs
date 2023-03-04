using ES.Application.Commands.CustomerCommands;
using ES.Application.Infrastructure;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.CustomerCases
{
    internal class UpdateCustomerCommandHandler : IHandler<UpdateCustomerCommand>
    {
        private readonly IRepository<Customer> _customersRepository;
        public UpdateCustomerCommandHandler(IRepository<Customer> customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task HandleAsync(UpdateCustomerCommand command, CancellationToken cancellation)
        {

            var customer = await _customersRepository.GetByIdAsync(command.CustomerId);
            var isChanged = false;
            var isChangedAddress = false;

            if(command.Email is not null && command.Email != customer.Email)
            {
                customer.Email = command.Email;
                isChanged = true;
            }

            if (command.Phone is not null && command.Phone != customer.Phone)
            {
                customer.Phone = command.Phone;
                isChanged = true;
            }

            if (command.FirstName is not null && command.FirstName != customer.FirstName)
            {
                customer.FirstName = command.FirstName;
                isChanged = true;
            }

            if (command.LastName is not null && command.LastName != customer.LastName)
            {
                customer.LastName = command.LastName;
                isChanged = true;
            }

            if (command.Country is not null && command.Country != customer.Address.Country)
            {
                customer.Address.Country = command.Country;
                isChanged = true;
            }

            if (command.City is not null && command.City != customer.Address.City)
            {
                customer.Address.City = command.City;
                //customer.Address = customer.Address with { City = command.City };
                isChanged = true;
            }

            if (command.Street is not null && command.Street != customer.Address.Street)
            {
                customer.Address.Street = command.Street;
                isChanged = true;
            }

            if (command.HouseNumber is not null && command.HouseNumber != customer.Address.HouseNumber)
            {
                customer.Address.HouseNumber = command.HouseNumber;
                isChanged = true;
            }

            if (command.FlatNumber is not null && command.FlatNumber != customer.Address.FlatNumber)
            {
                customer.Address.FlatNumber = command.FlatNumber;
                isChanged = true;
            }
            
            
            if (isChanged)
            {
                await _customersRepository.UpdateAsync(customer);
            }



        }
    }
}
