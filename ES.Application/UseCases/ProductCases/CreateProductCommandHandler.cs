using ES.Application.Commands.CategoryCommands;
using ES.Application.Commands.ProductCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.ProductCases
{
    internal class CreateProductCommandHandler : IHandler<CreateProductCommand, Guid>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Supplier> _supplierRepository;

        
        public CreateProductCommandHandler(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IRepository<Supplier> supplierRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            
        }

        public async Task<Guid> HandleAsync(CreateProductCommand command, CancellationToken cancellation)
        {
            var supplier = await _supplierRepository.GetByIdAsync(command.SupplierId);
            if(supplier is null)
            {
                throw new ApplicationException("Supplier not exist");
            }

            var category = await _categoryRepository.GetByIdAsync(command.CategoryId);
            if (category is null)
            {
                throw new ApplicationException("Category not exist");
            }

            /*var product = new Product()
            {
                Id = Guid.NewGuid(),
                Supplier = supplier,
                SupplierId = supplier.Id,
                Category = category,
                CategoryId = category.Id,
                Name = command.Name,
                Description = command.Description,
                Cost = command.Cost,
                IsStock = command.IsStock,
                ExpirationDate = command.ExpirationDate,
                ProductImageId = imageId
            };*/

            

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Supplier = supplier,
                SupplierId = supplier.Id,
                Category = category,
                CategoryId = category.Id,
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                ShelfLife = command.ShelfLife,
                ManufactureDate = command.ManufactureDate,
                Count = command.Count,
                Rating = command.Rating,
            };

            foreach(var charak in command.ProductCharaks)
            {
                product.ProductCharaks.Add(new ProductCharaks()
                {
                    Id = Guid.NewGuid(),
                    Key = charak.Key,
                    Value = charak.Value,
                    ProductId = product.Id,
                    Product = product,
                });
            }

            _productRepository.Add(product);

            return product.Id;

        }


    }
}
