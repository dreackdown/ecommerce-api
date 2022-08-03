using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSiteAPI.Context.Dtos.Product
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public decimal Price { get; set; }
    }
}
