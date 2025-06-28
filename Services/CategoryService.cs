using Company.DTO;
using Company.Model;
using Company.Repositories;
using Company.ViewModels;
namespace Company.Services
{
    public class CategoryService
    {
        #region Fields
        private readonly CategoryRepository _categoriesRepository;
        private readonly CompanyRepository _companyRepository;

        #endregion

        #region Constructor
        public CategoryService(
           CategoryRepository categoriesRepository,
           CompanyRepository companyRepository)


        {
            _categoriesRepository = categoriesRepository;
            _companyRepository = companyRepository;
        }

        #endregion

        #region GetAll
        public List<CategoryViewModel> GetAll()
        {
            var category = _categoriesRepository.GetAll();
            if (category is not null)
                return category.Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    CategoryCode = x.CategoryCode,
                    CompanyId = x.CompanyId,
                    CreatedAt = x.CreatedAt,

                }).ToList();
            throw new Exception("No Category found.");
        }
        #endregion GetAll

        #region Get
        public CategoryViewModel GetCategory(int id)
        {
            var cat = _categoriesRepository.Get(id);
            if (cat is not null)
                return new CategoryViewModel
                {
                    Id = cat.Id,
                    CategoryName = cat.CategoryName,
                    Description = cat.Description,
                    CreatedAt = cat.CreatedAt,
                };
            throw new Exception("Category not found or Invalid Id.");
        }
        #endregion Get

        #region Add
        public void Add(CategoryDto Cat)
        {

            if (Cat.CompanyId < 1)
                throw new Exception("CompanyId must be greater then 0");

            var company = _companyRepository.Get(Cat.CompanyId);
            if (company is null)
                throw new InvalidOperationException("Company not found");
            var categories = new Category
            {
                CategoryName = Cat.Name,
                Description = Cat.Description,
                CategoryCode = Cat.CategoryCode,
                CompanyId = Cat.CompanyId,
                CreatedAt = DateTime.UtcNow,
            };
            _categoriesRepository.Add(categories);
        }

        #endregion Add

        #region Update

        public bool Update(UpdateCategoryDto category)
        {
            try
            {
                var categoryDb = _categoriesRepository.Get(category.Id);
                if (categoryDb is null)
                {
                    throw new Exception("Product not found");
                }
                categoryDb.CategoryName = category.Name;
                categoryDb.Description = category.Description;
                categoryDb.CompanyId = category.CompanyId;
                categoryDb.CategoryCode = category.CategoryCode;
                categoryDb.UpdatedAt = DateTime.UtcNow;
                return _categoriesRepository.Update(categoryDb);
            }
            catch
            {
                throw new Exception("You are trying to update invalid ID");
            }
        }

        #endregion Update

        #region Delete
        public bool Delete(int categoryId)
        {
            try
            {
                var categoryDb = _categoriesRepository.Get(categoryId);
                if (categoryDb is null)
                {
                    throw new Exception("category not found");
                }
                return _categoriesRepository.Delete(categoryDb);
            }
            catch
            {
                throw new Exception("Invalid Id");
            }
        }
        #endregion Delete

    }
}
