using System.ComponentModel.DataAnnotations;

namespace EcommerceSiteAPI.Context.Dtos.Product
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public decimal Price { get; set; }
    }
}
