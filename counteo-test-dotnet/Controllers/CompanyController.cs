using Microsoft.AspNetCore.Mvc;
using counteo_test_dotnet.DTO;
using counteo_test_dotnet.Services;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase {

   private readonly ICompanyService _companyService;

   public CompanyController(ICompanyService companyService) {
      _companyService = companyService;
   }

   [HttpGet]
   public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies() {
      var companies = await _companyService.GetCompaniesAsync();
      return Ok(companies);
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<CompanyDTO>> GetCompany(int id) {
      var company = await _companyService.GetCompanyAsync(id);

      if (company == null) {
         return NotFound();
      }

      return company;
   }

   [HttpPut("{id}")]
   public async Task<IActionResult> PutCompany(int id, CompanyDTO companyDTO) {
      var success = await _companyService.UpdateCompanyAsync(id, companyDTO);

      if (!success) {
         return BadRequest();
      }

      return NoContent();
   }

   [HttpPost]
   public async Task<ActionResult<CompanyDTO>> PostCompany([FromBody] CompanyDTO companyDTO) {
      if (companyDTO == null) {
         return BadRequest("CompanyDTO cannot be null");
      }

      var result = await _companyService.AddCompanyAsync(companyDTO);

      if (!result.Success) {
         return Conflict(result.ErrorMessage);
      }

      var createdCompanyDTO = await _companyService.GetCompanyAsync(result.Company.Id);
      return CreatedAtAction(nameof(GetCompany), new { id = result.Company.Id }, createdCompanyDTO);
   }

   [HttpDelete("{id}")]
   public async Task<IActionResult> DeleteCompany(int id) {
      var success = await _companyService.DeleteCompanyAsync(id);

      if (!success) {
         return NotFound();
      }

      return NoContent();
   }
}
