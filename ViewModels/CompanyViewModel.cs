namespace Company.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Headquarterslocation { get; set; }
        public string Founders { get; set; }
        public decimal Revenue { get; set; }
        public string Website { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
