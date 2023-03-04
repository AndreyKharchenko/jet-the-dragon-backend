using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.CategoryCommands
{
    public sealed class UpdateCategoryCommand
    {
        [Required]
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
