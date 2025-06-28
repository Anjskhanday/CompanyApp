using Company.DTO;
using Company.Model;
using Company.Repositories;
using Company.ViewModels;
namespace Company.Services
{
    public class CompanyService
    {
        #region Fields
        private readonly CompanyRepository _companyRepository;
        private readonly CategoryRepository _categoriesRepository;
        private int categoryid;

        public int categoryId { get; private set; }

        #endregion

        #region Constructor
        public CompanyService(
           CompanyRepository companyRepository,
           CategoryRepository categoriesRepository)


        {
            _companyRepository = companyRepository;
            _categoriesRepository = categoriesRepository;
        }

        #endregion

        #region GetAll
        public List<CCPViewModel> GetAllDetails()
        {
            var companies = _companyRepository.GetAllDetails();

            return companies;
            //if (companies is null)
            //    throw new Exception("No Company found.");
        }
        #endregion GetAll

        #region GetAll
        public List<CompanyViewModel> GetAll()
        {
            var companies = _companyRepository.GetAll();
            if (companies is not null)
            {
                var res = companies
                 .Select(x => new CompanyViewModel
                 {
                     Id = x.Id,
                     CompanyName = x.CompanyName,
                     Industry = x.Industry,
                     Headquarterslocation = x.Headquarterslocation,
                     Founders = x.Founders,
                     Revenue = x.Revenue,
                     Website = x.Website,
                     IsActive = x.IsActive,
                     CreatedAt = x.CreatedAt,
                     UpdatedAt = x.UpdatedAt,
                 })
                 .ToList();
                return res;
            }
            else
                throw new Exception("No Company found.");
        }
        #endregion GetAll

        #region Get
        public CompanyViewModel GetCompany(int id)
        {
            if (id < 1)
                throw new Exception("Id must be greater then 0");
            var company = _companyRepository.Get(id);
            if (company is not null)
                return new CompanyViewModel
                {
                    Id = company.Id,
                    CompanyName = company.CompanyName,
                    CreatedAt = company.CreatedAt,
                    UpdatedAt = company.UpdatedAt,
                };
            throw new Exception("Company not found.");
        }
        #endregion Get

        #region GetBool

        public List<CompanyViewModel> GetByBool(bool? isActive)
        {
            List<CompanyA> companies;

            if (isActive.HasValue)
            {
                companies = _companyRepository.GetByStatus(isActive.Value);
            }
            else
            {
                companies = _companyRepository.GetAll(); // Assumes this method exists to fetch all companies
            }

            if (companies == null || !companies.Any())
                throw new Exception("No companies found.");

            var result = companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                Industry = x.Industry,
                Headquarterslocation = x.Headquarterslocation,
                Founders = x.Founders,
                Revenue = x.Revenue,
                Website = x.Website,
                IsActive = x.IsActive,
                CreatedAt = DateTime.UtcNow
            }).ToList();

            return result;
        }


        #endregion GetBool

        #region Add
        public void Add(CompanyDto Cat)
        {

            var companyDb = _companyRepository.Find(Cat.Name);
            if (companyDb != null)
            {
                throw new Exception("Company already exists.");
            }


            var company = new CompanyA
            {
                CompanyName = Cat.Name,
                Industry = Cat.Industry,
                Headquarterslocation = Cat.Headquarterslocation,
                Founders = Cat.Founders,
                Revenue = Cat.Revenue,
                Website = Cat.Website,
                IsActive = Cat.IsActive,
                CreatedAt = DateTime.UtcNow,
            };

            _companyRepository.Add(company);
        }
        #endregion Add

        #region Update

        public bool Update(UpdateCompanyDto company)
        {
            try
            {
                var companyDb = _companyRepository.Get(company.Id);
                if (companyDb is null)
                {
                    throw new Exception("Company not found");
                }
                companyDb.CompanyName = company.Name;
                companyDb.Industry = company.Industry;
                companyDb.Headquarterslocation = company.Headquarterslocation;
                companyDb.Founders = company.Founders;
                companyDb.Revenue = company.Revenue;
                companyDb.Website = company.Website;
                companyDb.UpdatedAt = DateTime.UtcNow;
                return _companyRepository.Update(companyDb);
            }
            catch
            {
                throw;
            }
        }

        #endregion Update

        #region Delete
        public bool Delete(int companyId)
        {

            var linkedCategories = _categoriesRepository.GetAll()
                                        .Where(x => x.CompanyId == companyId)
                                        .ToList();

            if (linkedCategories.Any())
            {
                throw new InvalidOperationException("Cannot delete the company because it has linked categories.");
            }


            var companyDb = _companyRepository.Get(companyId);
            if (companyDb == null)
            {
                throw new KeyNotFoundException($"Company with ID {companyId} not found.");
            }

            return _companyRepository.Delete(companyDb);
        }
        #endregion Delete

    }
}
