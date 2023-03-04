using ES.Application.Commands.CategoryCommands;
using ES.Application.Commands.SupplierCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.SupplierCases
{
    internal class CreateSupplierCommandHandler : IHandler<CreateSupplierCommand, Guid>
    {
        private readonly IRepository<Supplier> _suppliersRepository;
        private readonly IRepository<Customer> _customersRepository;

        public CreateSupplierCommandHandler(IRepository<Supplier> suppliersRepository, IRepository<Customer> customersRepository)
        {
            _suppliersRepository = suppliersRepository;
            _customersRepository = customersRepository;
        }

        public async Task<Guid> HandleAsync(CreateSupplierCommand command, CancellationToken cancellation)
        {
            /*var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = command.FirstName,
                LastName = command.LastName,
                Phone = command.Phone,
                Email = command.Email,
                Address = new Address()
                {
                    Country = command.Country,
                    Region = command.Region,
                    City = command.City,
                    Street = command.Street,
                    HouseNumber = command.HouseNumber,
                }
            };*/
            var customer = await _customersRepository.GetByIdAsync(command.CustomerId);

            if(customer is null)
            {
                throw new ApplicationException("Customer not found");
            }


            var supplier = new Supplier()
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                Customer = customer,
                OrgType = command.OrgType,
                INN = command.INN,
                Name = command.Name,
                OGRNIP = command.OGRNIP,
                DeclarationNum = command.DeclarationNum,
                DeclarationDate = command.DeclarationDate,
                SanBookNum = command.SanBookNum,
                SanBookDate = command.SanBookDate,
                Description = command.Description,
            };

            _suppliersRepository.Add(supplier);

            return supplier.Id;

        }
    }
}
