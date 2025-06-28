using Company.Model;

namespace Company.Repositories
{
    public class ProductRepository
    {
        #region Fields
        private readonly CompanyDbContext.CompanyDbContext _companyDbContext;
        #endregion

        #region Constructor
        public ProductRepository(CompanyDbContext.CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }
        #endregion Constructor

        #region GetAll
        public List<Product> GetAll()
        {
            return _companyDbContext.Products.ToList();
        }
        #endregion GetAll

        #region Add
        public void Add(Product Pro)
        {

            /*var product = new Product
            {


                Name = Pro.Name,
                ProductCode = Pro.ProductCode,
                CategoryId = Pro.CategoryId,
                CreatedAt = DateTime.UtcNow,
            };*/

            _companyDbContext.Products.Add(Pro);
            _companyDbContext.SaveChanges();
            return;
        }
        #endregion Add

        #region Update
        public bool Update(Product product)
        {
            _companyDbContext.Update(product);
            if (_companyDbContext.SaveChanges() > 0)
                return true;
            return false;
        }
        #endregion Update

        #region Get
        public Product Get(int productid)
        {
            var productDb = _companyDbContext.Products.Find(productid);
            if (productDb == null) return null;
            return productDb;
        }
        #endregion Get

        #region Delete
        public bool Delete(Product product)
        {
            _companyDbContext.Remove(product);
            if (_companyDbContext.SaveChanges() > 0)
                return true;
            return false;
        }
        #endregion Delete
    }
}
