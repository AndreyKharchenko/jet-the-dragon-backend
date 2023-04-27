using ES.Application.Dtos;
using ES.Application.Infrastructure;
using ES.Application.Queries;
using ES.Application.Services;
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
    public class SupplierOrdersActiveQueryHandler : IHandler<SupplierOrderActiveQuery, IEnumerable<OrderConfirmPayDto>>
    {
        private readonly EsDbContext _dbContext;
        private readonly IAuthSupplierProvider _authSupplierProvider;

        public SupplierOrdersActiveQueryHandler(EsDbContext dbContext, IAuthSupplierProvider authSupplierProvider)
        {
            _dbContext = dbContext;
            _authSupplierProvider = authSupplierProvider;
        }

        public async Task<IEnumerable<OrderConfirmPayDto>> HandleAsync(SupplierOrderActiveQuery query, CancellationToken cancellation)
        {
            var supplier = _authSupplierProvider.GetAuthSupplier();

            if(supplier is null)
            {
                throw new ApplicationException("Supplier not found");
            }

            var supplierId = supplier.Id;

            var supplierOrderActive = 
                _dbContext
                .Set<Order>()
                .Include(x => x.Cart)
                .Include(x => x.Product)   
                    .ThenInclude(x => x.Supplier)
                    .ThenInclude(x => x.Customer)
                .AsQueryable(); // составляем SQL запрос SELECT * FROM Order



            supplierOrderActive =
                supplierOrderActive
                .Where(a => (a.Product.SupplierId == supplierId && a.Cart.Status == CartStatus.ConfirmPay));

            return await supplierOrderActive.Select(x => new OrderConfirmPayDto()
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
                isWholesale = x.isWholesale,
                CartPaymentType = x.Cart.PaymentType,
                CartDeliveryType = x.Cart.DeliveryType,
                SupplierAddres = $"{x.Product.Supplier.Customer.Address.Country}, {x.Product.Supplier.Customer.Address.City}, {x.Product.Supplier.Customer.Address.Street}, {x.Product.Supplier.Customer.Address.HouseNumber}",
                ProductImage = _dbContext.Set<Image>().Where(i => i.SubjectId == x.ProductId).Select(i => i.Id).FirstOrDefault(),
            }).GetListPageQuery(query).ToListAsync();


        }
    }
}
