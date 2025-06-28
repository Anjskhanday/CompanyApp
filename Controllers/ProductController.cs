using Company.DTO;
using Company.Services;
using Company.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Company.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        #region GetAll
        [HttpGet("GetAll")]
        public ActionResult<ProductViewModel> GetAll()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get

        #region Add
        [HttpPost("Add")]
        public ActionResult Add([FromBody] ProductDto productDto)
        {
            try
            {
                _productService.Add(productDto);
                return Ok("Product added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion Add

        #region update


        [HttpPut("update")]
        public ActionResult update([FromBody] UpdateProductDto updateProductDto)
        {
            try
            {
                _productService.Update(updateProductDto);
                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion update

        #region Get
        [HttpGet("Get/{Id}")]
        public ActionResult<ProductViewModel> Get([FromRoute] int Id)
        {
            try
            {
                return Ok(_productService.GetProduct(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get

        #region Delete
        [HttpDelete("Delete/{Id}")]
        public ActionResult<ProductViewModel> Remove([FromRoute] int Id)
        {
            try
            {
                return Ok(_productService.Delete(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Delete
    }
}
