using Company.Model;

namespace Company.Repositories
{
    public class CategoryRepository
    {
        #region Fields
        private readonly CompanyDbContext.CompanyDbContext _companyDbContext;
        #endregion

        #region Constructor
        public CategoryRepository(CompanyDbContext.CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }
        #endregion Constructor

        #region GetAll
        public List<Category> GetAll()
        {
            return _companyDbContext.Categories.ToList();
        }
        #endregion GetAll

        #region Get
        public Category Get(int categoryid)
        {
            var categoryDb = _companyDbContext.Categories.Find(categoryid);
            if (categoryDb == null) return null;
            return categoryDb;
        }
        #endregion Get

        #region Add
        public void Add(Category Cat)
        {
            _companyDbContext.Categories.Add(Cat);
            _companyDbContext.SaveChanges();
            return;
        }
        #endregion Add

        #region Update
        public bool Update(Category category)
        {
            _companyDbContext.Update(category);
            if (_companyDbContext.SaveChanges() > 0)
                return true;
            return false;
        }
        #endregion Update

        #region Delete
        public bool Delete(Category category)
        {
            _companyDbContext.Remove(category);
            if (_companyDbContext.SaveChanges() > 0)
                return true;
            return false;
        }
        #endregion Delete

    }
}
