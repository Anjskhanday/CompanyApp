using System.ComponentModel.DataAnnotations;

namespace Company.DTO
{
    public class UpdateCompanyDto
    {
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Headquarterslocation { get; set; }
        public string Founders { get; set; }
        public decimal Revenue { get; set; }
        public string Website { get; set; }
        public bool IsActive { get; set; }
    }
}
