using Company.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Model
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public string CategoryCode { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public CompanyA Companies { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
