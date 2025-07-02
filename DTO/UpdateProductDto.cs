using System.ComponentModel.DataAnnotations;

namespace Company.DTO
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "CategoryId is Required.")]
        public int CategoryId { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductWarenty { get; set; }

    }
}
