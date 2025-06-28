using Company.DTO;
using Company.Services;
using Company.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Company.Controllers

{
    #region Controller
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }
        #endregion

        #region GetAll
        [HttpGet("GetAllDetails")]
        public ActionResult<CCPViewModel> GetAllDetails()
        {
            try
            {
                return Ok(_companyService.GetAllDetails());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get

        #region GetAll
        [HttpGet("GetAll")]
        public ActionResult<CompanyViewModel> GetAll()
        {
            try
            {
                return Ok(_companyService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get

        #region Get
        [HttpGet("Get/{Id}")]
        public ActionResult<CompanyViewModel> Get([FromRoute] int Id)
        {
            try
            {
                return Ok(_companyService.GetCompany(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion Get



        #region Add
        [HttpPost("Add")]
        public ActionResult Add([FromBody] CompanyDto companyDto)
        {
            try
            {
                _companyService.Add(companyDto);
                return Ok("Company added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion Add

        #region GetBool

        [HttpGet("Bool")]
        public IActionResult GetCompanies([FromQuery] bool? isActive = null)
        {
            var result = _companyService.GetByBool(isActive);
            return Ok(result);
        }

        #endregion GetBool


        #region update


        [HttpPut("update")]
        public ActionResult update([FromBody] UpdateCompanyDto updateCompanyDto)
        {
            try
            {
                _companyService.Update(updateCompanyDto);
                return Ok("Company updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion update

        #region Delete
        [HttpDelete("{companyId}")]
        public IActionResult Remove(int companyId)
        {
            try
            {
                var result = _companyService.Delete(companyId);
                if (result)
                    return NotFound("Company not found or could not be deleted.");

                return Ok($"Company with ID {companyId} was deleted successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion Delete
    }
}
