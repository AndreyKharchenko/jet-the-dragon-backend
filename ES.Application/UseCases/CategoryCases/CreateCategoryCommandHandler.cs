using ES.Application.Commands.CategoryCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.CategoryCases
{
    internal class CreateCategoryCommandHandler: IHandler<CreateCategoryCommand, Guid>
    {
        private readonly IRepository<Category> _categoryRepository;
        
        public CreateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> HandleAsync(CreateCategoryCommand command, CancellationToken cancellation)
        {
            

            var category = new Category() { 
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
            };

            _categoryRepository.Add(category);

            return category.Id;

        }
    }
}
