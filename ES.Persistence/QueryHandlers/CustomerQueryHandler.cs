using ES.Application.Dtos;
using ES.Application.Infrastructure;
using ES.Application.Queries;
using ES.Application.UseCases;
using ES.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.QueryHandlers
{
    public class CustomerQueryHandler : IHandler<CustomerQuery, CustomerDto>
    {
        private readonly EsDbContext _dbContext;
        private readonly ILoginNameProvider _loginNameProvider;

        public CustomerQueryHandler(EsDbContext dbContext, ILoginNameProvider loginNameProvider)
        {
            _dbContext = dbContext;
            _loginNameProvider = loginNameProvider;
        }

        public async Task<CustomerDto> HandleAsync(CustomerQuery query, CancellationToken cancellation)
        {
            var email = _loginNameProvider.CurrentLoginName;
            if(email == null)
            {
                return null;
            }
            return await _dbContext.Set<Customer>()
                .Where(a => a.Email == email)
                .Select(a => new CustomerDto() {
                    Email = a.Email,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Country = a.Address.Country,
                    City = a.Address.City,
                    HouseNumber = a.Address.HouseNumber,
                    FlatNumber = a.Address.FlatNumber,
                    Street = a.Address.Street,
                    Phone = a.Phone,
                    Id = a.Id
                })
                .FirstOrDefaultAsync();

            
            
        }
    }
}
