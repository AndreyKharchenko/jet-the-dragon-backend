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
    public class SupplierQueryHandler : IHandler<SuppliersQuery, SupplierDto>
    {
        private readonly EsDbContext _dbContext;
        private readonly ILoginNameProvider _loginNameProvider;

        public SupplierQueryHandler(EsDbContext dbContext, ILoginNameProvider loginNameProvider)
        {
            _dbContext = dbContext;
            _loginNameProvider = loginNameProvider;
        }

        public async Task<SupplierDto> HandleAsync(SuppliersQuery query, CancellationToken cancellation)
        {
            var email = _loginNameProvider.CurrentLoginName;
            if (email == null)
            {
                return null;
            }
            return await _dbContext.Set<Supplier>()
                .Include(a => a.Customer)
                .Where(a => a.Customer.Email == email)
                .Select(a => new SupplierDto()
                {
                    Id = a.Id,
                    FirstName = a.Customer.FirstName,
                    LastName = a.Customer.LastName,
                    Phone = a.Customer.Phone,
                    Email = a.Customer.Email,
                    Country = a.Customer.Address.Country,
                })
                .FirstOrDefaultAsync();
        }
    }
}
