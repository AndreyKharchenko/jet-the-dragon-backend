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
    public class CartQueryHandler : IHandler<CartQuery, CartDto>
    {
        private readonly EsDbContext _dbContext;
       

        public CartQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CartDto> HandleAsync(CartQuery query, CancellationToken cancellation)
        {
            return await _dbContext.Set<Cart>()
                .Include(x => x.Customer)
                .Where(x => (x.Customer.Id == query.CustomerId && x.Status == CartStatus.Created))
                .Select(x => new CartDto()
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    TotalCount = x.TotalCount,
                    TotalCost = x.TotalCost,
                    DeliveryType = x.DeliveryType,
                    PaymentType = x.PaymentType,
                })
                .FirstOrDefaultAsync();
        }
    }
}
