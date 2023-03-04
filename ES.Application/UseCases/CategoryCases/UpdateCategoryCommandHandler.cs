using ES.Application.Commands.CategoryCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.CategoryCases
{
    internal class UpdateCategoryCommandHandler : IHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepository;
        public UpdateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task HandleAsync(UpdateCategoryCommand command, CancellationToken cancellation)
        {


            var category = await _categoryRepository.GetByIdAsync(command.CategoryId);
            var isChanged = false;

            if (command.Description is not null && command.Description != category.Description)
            {
                category.Description = command.Description;
                isChanged = true;
            }

            if (command.Name is not null && command.Name != category.Name)
            {
                category.Name = command.Name;
                isChanged = true;
            }


            if(isChanged)
            {
                await _categoryRepository.UpdateAsync(category);
            }
        }
    }
}
