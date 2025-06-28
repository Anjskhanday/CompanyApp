using Company.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Model
{
    public class Product : BaseModel
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductWarenty { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Categories { get; set; }

    }
}
