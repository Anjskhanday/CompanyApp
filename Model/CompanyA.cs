using Company.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace Company.Model
{
    public class CompanyA : BaseModel
    {
        public string Website { get; set; }
        public bool? IsActive { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string Industry { get; set; }
        public string? Headquarterslocation { get; set; }
        public string? Founders { get; set; }
        public decimal Revenue { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}
