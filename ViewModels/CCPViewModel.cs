namespace Company.ViewModels
{
    public class CCPViewModel
    {

        public List<ProductVM> ProductVM { get; set; }
        public List<CategoryVM> CategoryVM { get; set; }
        public CompanyVM CompanyVM { get; set; }
    }
    //public class AllDataVM
    //    {
    //        public CompanyVM CompanyVM { get; set; }
    //        public List<CategoryVM> CategoryVM { get; set; }
    //        public List<ProductVM> ProductVM { get; set; }

    //    }

    public class CompanyVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
    }

    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
    }
}
