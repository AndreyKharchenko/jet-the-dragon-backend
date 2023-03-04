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
    internal class UpdateProductCommandHandler : IHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Supplier> _supplierRepository;
        public UpdateProductCommandHandler(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IRepository<Supplier> supplierRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task HandleAsync(UpdateProductCommand command, CancellationToken cancellation)
        {

            var product = await _productRepository.GetByIdAsync(command.ProductId);
            var isChanged = false;

            if(command.SupplierId is not null)
            {
                var supplier = await _supplierRepository.GetByIdAsync(command.SupplierId.Value);
                if (supplier is null)
                {
                    throw new ApplicationException("Supplier not exist");
                }

                product.Supplier = supplier;
                product.SupplierId = command.SupplierId.Value;
            } 
            
            if(command.CategoryId is not null)
            {
                var category = await _categoryRepository.GetByIdAsync(command.CategoryId.Value);
                if (category is null)
                {
                    throw new ApplicationException("Category not exist");
                }

                product.Category = category;
                product.CategoryId = command.CategoryId.Value;
            }
            

            

            if (command.Name is not null && command.Name != product.Name)
            {
                product.Name = command.Name;
                isChanged= true;
            }

            if (command.Description is not null && command.Description != product.Description)
            {
                product.Description = command.Description;
                isChanged= true;
            }

            if (command.Price is not null && command.Price != product.Price)
            {
                product.Price = command.Price.Value;
                isChanged = true;
            }

            if(command.ShelfLife is not null && command.ShelfLife != product.ShelfLife)
            {
                product.ShelfLife = command.ShelfLife.Value;
                isChanged= true;
            }

            if (command.ManufactureDate is not null && command.ManufactureDate != product.ManufactureDate)
            {
                product.ManufactureDate = command.ManufactureDate.Value;
                isChanged = true;
            }

            if(command.ProductCharaks is not null)
            {
                product.ProductCharaks.Clear();

                foreach (var charak in command.ProductCharaks)
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

                isChanged= true;
            }
            

            if(command.Count is not null && command.Count != product.Count)
            {
                product.Count = command.Count.Value;
                isChanged = true;
            }

            if (command.Rating is not null && command.Rating != product.Rating)
            {
                product.Rating = command.Rating.Value;
                isChanged = true;
            }


            if (isChanged)
            {
                await _productRepository.UpdateAsync(product);
            }
        }
    }
}
