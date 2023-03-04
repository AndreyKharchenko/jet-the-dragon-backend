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
    internal class UpdateSupplierCommandHandler : IHandler<UpdateSupplierCommand>
    {
        private readonly IRepository<Supplier> _suppliersRepository;
        public UpdateSupplierCommandHandler(IRepository<Supplier> suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public async Task HandleAsync(UpdateSupplierCommand command, CancellationToken cancellation)
        {
            var supplier = await _suppliersRepository.GetByIdAsync(command.SupplierId);
            //var customer = supplier.Customer;
            var isChanged = false;

            /*if(command.FirstName is not null  && command.FirstName != customer.FirstName)
            {
                customer.FirstName = command.FirstName;
                isChanged = true;
            }

            if (command.LastName is not null && command.LastName != customer.LastName)
            {
                customer.LastName = command.LastName;
                isChanged = true;
            }

            if (command.Phone is not null && command.Phone != customer.Phone)
            {
                customer.Phone = command.Phone;
                isChanged = true;
            }

            if (command.Email is not null && command.Email != customer.Email)
            {
                customer.Email = command.Email;
                isChanged = true;
            }

            if (command.Country is not null && command.Country != customer.Address.Country)
            {
                customer.Address.Country = command.Country;
                isChanged = true;
            }

            if (command.Region is not null && command.Region != customer.Address.Region)
            {
                customer.Address.Region = command.Region;
                isChanged = true;
            }

            if (command.City is not null && command.City != customer.Address.City)
            {
                customer.Address.City = command.City;
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
            }*/

            if (command.OrgType is not null && command.OrgType != supplier.OrgType)
            {
                supplier.OrgType = command.OrgType;
                isChanged = true;
            }

            if (command.INN is not null && command.INN != supplier.INN)
            {
                supplier.INN = command.INN;
                isChanged = true;
            }

            if (command.Name is not null && command.Name != supplier.Name)
            {
                supplier.Name = command.Name;
                isChanged = true;
            }

            if (command.OGRNIP is not null && command.OGRNIP != supplier.OGRNIP)
            {
                supplier.OGRNIP = command.OGRNIP;
                isChanged = true;
            }

            if (command.DeclarationNum is not null && command.DeclarationNum != supplier.DeclarationNum)
            {
                supplier.DeclarationNum = command.DeclarationNum;
                isChanged = true;
            }

            if (command.DeclarationDate != supplier.DeclarationDate)
            {
                supplier.DeclarationDate = command.DeclarationDate;
                isChanged = true;
            }

            if (command.SanBookNum is not null && command.SanBookNum != supplier.SanBookNum)
            {
                supplier.SanBookNum = command.SanBookNum;
                isChanged = true;
            }

            if (command.SanBookDate != supplier.SanBookDate)
            {
                supplier.SanBookDate = command.SanBookDate;
                isChanged = true;
            }

            if (command.Description is not null && command.Description != supplier.Description)
            {
                supplier.Description = command.Description;
                isChanged = true;
            }


            if (isChanged)
            {
                await _suppliersRepository.UpdateAsync(supplier);
            }
        }
    }
}
