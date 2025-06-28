using Company.DTO;
using Company.Services;
using Company.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Company.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoriesService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(CategoryService categoryService)
        {
            _categoriesService = categoryService;
        }

        #region GetAll
        [HttpGet("GetAll")]
        public ActionResult<CategoryViewModel> GetAll()
        {
            try
            {
                return Ok(_categoriesService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get

        #region Get
        [HttpGet("Get/{Id}")]
        public ActionResult<CategoryViewModel> Get([FromRoute] int Id)
        {
            try
            {
                return Ok(_categoriesService.GetCategory(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get

        #region Add
        [HttpPost("Add")]
        public ActionResult Add([FromBody] CategoryDto categoriesDto)
        {
            try
            {
                _categoriesService.Add(categoriesDto);
                return Ok("Category added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion Add

        #region update


        [HttpPut("update")]
        public ActionResult update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                _categoriesService.Update(updateCategoryDto);
                return Ok("Category updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion update

        #region Delete
        [HttpDelete("Delete/{Id}")]
        public ActionResult<CategoryViewModel> Remove([FromRoute] int Id)
        {
            try
            {
                return Ok(_categoriesService.Delete(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Delete


        //[HttpGet("GetAllData")]
        //public ActionResult<CCPViewModel> GetAllData()
        //{
        //    try
        //    {
        //        return Ok(_categoriesService.GetALLData());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
