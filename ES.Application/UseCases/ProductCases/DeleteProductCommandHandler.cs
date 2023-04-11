using ES.Application.Commands.ProductCommands;
using ES.Application.Infrastructure;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.ProductCases
{
    internal class DeleteProductCommandHandler : IHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _productRepository;
        //private readonly IRepository<Category> _categoryRepository;
        //private readonly IRepository<Supplier> _supplierRepository;
        private readonly ILoginNameProvider _loginNameProvider;
        public DeleteProductCommandHandler(IRepository<Product> productRepository, ILoginNameProvider loginNameProvider)
        {
            _productRepository = productRepository;
            //_categoryRepository = categoryRepository;
            //_supplierRepository = supplierRepository;
            _loginNameProvider = loginNameProvider;
        }

        public async Task HandleAsync(DeleteProductCommand command, CancellationToken cancellation)
        {
            var email = _loginNameProvider.CurrentLoginName;
            if (email == null)
            {
                throw new ApplicationException("Email of supplier not exist");
            }

            var product = await _productRepository.GetByIdAsync(command.ProductId);
            
            if(product is null)
            {
                throw new ApplicationException("Product not exist");
            }

            product.State = EntityState.Removed;

            await _productRepository.UpdateAsync(product);
        }
    }
}
