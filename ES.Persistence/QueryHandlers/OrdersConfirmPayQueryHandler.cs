using ES.Application.Dtos;
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
    public class OrdersConfirmPayQueryHandler : IHandler<OrderConfirmPayQuery, IEnumerable<OrderConfirmPayDto>>
    {
        private readonly EsDbContext _dbContext;

        public OrdersConfirmPayQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderConfirmPayDto>> HandleAsync(OrderConfirmPayQuery query, CancellationToken cancellation)
        {
            var orderConfirmPayQuery = 
                _dbContext
                .Set<Order>()
                .Include(x => x.Cart)
                .Include(x => x.Product)   
                    .ThenInclude(x => x.Supplier)
                    .ThenInclude(x => x.Customer)
                .AsQueryable(); // составляем SQL запрос SELECT * FROM Order



            orderConfirmPayQuery = 
                orderConfirmPayQuery
                .Where(a => (a.Cart.CustomerId == query.CustomerId && (a.Cart.Status == CartStatus.ConfirmPay || a.Cart.Status == CartStatus.Delivered)));

            return await orderConfirmPayQuery.Select(x => new OrderConfirmPayDto()
            {
                Id = x.Id,
                CartId = x.CartId,
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                ProductManufactureDate = x.Product.ManufactureDate,
                ProductPrice = x.Product.Price,
                ProductUnit = x.Product.Unit,
                Count = x.Count,
                Cost = x.Cost,
                CreateDate = x.CreateDate,
                CartPaymentType = x.Cart.PaymentType,
                CartDeliveryType = x.Cart.DeliveryType,
                SupplierAddres = $"{x.Product.Supplier.Customer.Address.Country}, {x.Product.Supplier.Customer.Address.City}, {x.Product.Supplier.Customer.Address.Street}, {x.Product.Supplier.Customer.Address.HouseNumber}",
                ProductImage = _dbContext.Set<Image>().Where(i => i.SubjectId == x.ProductId).Select(i => i.Id).FirstOrDefault(),
            }).GetListPageQuery(query).ToListAsync();


        }
    }
}
