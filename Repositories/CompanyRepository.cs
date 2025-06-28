using Company.Model;
using Company.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories
{
    public class CompanyRepository
    {
        #region Fields
        private readonly CompanyDbContext.CompanyDbContext _companyDbContext;
        #endregion

        #region Constructor
        public CompanyRepository(CompanyDbContext.CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }
        #endregion Constructor

        #region GetAll
        public List<CCPViewModel> GetAllDetails()
        {
            var result = new List<CCPViewModel>();

            var data = _companyDbContext.Companies.Include(x => x.Categories).ThenInclude(x => x.Products).ToList();

            foreach (var item in data)
            {

                var allData = new CCPViewModel()

                {
                    CompanyVM = new CompanyVM()
                    {
                        Id = item.Id,
                        Name = item.CompanyName,
                    },

                    CategoryVM = item.Categories.Select(category => new CategoryVM
                    {
                        Id = category.Id,
                        CategoryCode = category.CategoryCode,
                        Name = category.CategoryName
                    }).ToList(),


                    ProductVM = item.Categories
                        .SelectMany(category => category.Products)
                        .Select(product => new ProductVM
                        {
                            Id = product.Id,
                            Name = product.ProductName,
                            ProductCode = product.ProductCode,
                        }).ToList()
                };

                result.Add(allData);
            }
            return result;
        }

        #endregion GetAll

        #region GetAll
        public List<CompanyA> GetAll()
        {
            return _companyDbContext.Companies.ToList();
        }

        #endregion GetAll

        #region Get
        public CompanyA Get(int companyid)
        {
            var companyDb = _companyDbContext.Companies.Find(companyid);
            if (companyDb == null) return null;
            return companyDb;
        }
        #endregion Get

        #region GetBool
        public List<CompanyA> GetByStatus(bool isActive)
        {
            return _companyDbContext.Companies
                .Where(x => x.IsActive == isActive)
                .ToList();
        }

        #endregion GetBool

        #region Add
        public void Add(CompanyA Cat)
        {
            _companyDbContext.Companies.Add(Cat);
            _companyDbContext.SaveChanges();
            return;
        }
        #region Validation
        public CompanyA? Find(string name)
        {
            return _companyDbContext.Companies
                .FirstOrDefault(x => x.CompanyName.ToLower().Trim() == name.ToLower().Trim());
        }
        #endregion Validation
        #endregion Add

        #region Update
        public bool Update(CompanyA company)
        {
            _companyDbContext.Update(company);
            if (_companyDbContext.SaveChanges() > 0)
                return true;
            return false;
        }
        #endregion Update

        #region Delete
        public bool Delete(CompanyA company)
        {
            _companyDbContext.Remove(company);
            if (_companyDbContext.SaveChanges() > 0)
                return true;
            return false;
        }


        #endregion Delete


    }
}
