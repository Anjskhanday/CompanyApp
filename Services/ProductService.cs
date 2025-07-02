using Company.DTO;
using Company.Model;
using Company.Repositories;
using Company.ViewModels;
namespace Company.Services
{
    public class ProductService
    {
        #region Fields
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;
        #endregion

        #region Constructor
        public ProductService(
             ProductRepository productRepository,
             CategoryRepository categoryRepository)


        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region GetAll
        public List<ProductViewModel> GetAll()
        {
            var product = _productRepository.GetAll();
            if (product is not null)
                return product.Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    CategoryId = x.CategoryId,
                    ProductCode = x.ProductCode,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    ProductWarenty = x.ProductWarenty,
                    ProductBrand = x.ProductBrand,
                    ProductPrice = x.ProductPrice
                }).ToList();
            throw new Exception("No Product found.");
        }
        #endregion GetAll

        #region Get
        public ProductViewModel GetProduct(int id)
        {
            if (id < 1)
                throw new Exception("Id must be greater then 0");
            var product = _productRepository.Get(id);
            if (product is not null)
                return new ProductViewModel
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt,
                    ProductWarenty = product.ProductWarenty,
                    ProductBrand = product.ProductBrand,
                    ProductPrice = product.ProductPrice,
                };
            throw new Exception("Product not found.");
        }
        #endregion Get

        #region Add
        public void Add(ProductDto Pro)
        {

            if (Pro.CategoryId < 1)
                throw new Exception("CompanyId must be greater then 0");

            var pro = _categoryRepository.Get(Pro.CategoryId);
            if (pro is null)
                throw new Exception("Category not found");


            var productDb = _productRepository.Find(Pro.Name);
            if (productDb != null)
            {
                throw new Exception("Product name already exists");
            }

            var product = new Product
            {
                ProductName = Pro.Name,
                ProductCode = Pro.ProductCode,
                CategoryId = Pro.CategoryId,
                CreatedAt = DateTime.UtcNow,
                ProductWarenty = Pro.ProductWarenty,
                ProductBrand = Pro.ProductBrand,
                ProductPrice = Pro.ProductPrice
            };

            _productRepository.Add(product);
        }

        #endregion Add

        #region Update

        public bool Update(UpdateProductDto product)
        {
            try
            {
                var productDb = _productRepository.Get(product.ProductId);
                if (productDb is null)
                {
                    throw new Exception("Product not found");
                }
                productDb.ProductName = product.Name;
                productDb.ProductCode = product.ProductCode;
                productDb.CategoryId = product.CategoryId;
                productDb.ProductWarenty = product.ProductWarenty;
                productDb.ProductBrand = product.ProductBrand;
                productDb.ProductPrice = product.ProductPrice;
                productDb.UpdatedAt = DateTime.UtcNow;
                return _productRepository.Update(productDb);
            }
            catch
            {
                throw new Exception("Id not present");
            }
        }

        #endregion Update

        #region Delete
        public bool Delete(int productId)
        {
            try
            {
                var productDb = _productRepository.Get(productId);
                if (productDb is null)
                {
                    throw new Exception("Product not found");
                }
                return _productRepository.Delete(productDb);
            }
            catch
            {
                throw new Exception("Id not present");
            }
        }
        #endregion Delete
    }
}
