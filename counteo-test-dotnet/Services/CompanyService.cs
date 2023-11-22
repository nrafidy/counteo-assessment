

using counteo_test_dotnet.Data;
using counteo_test_dotnet.DTO;
using counteo_test_dotnet.Mappers;
using counteo_test_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace counteo_test_dotnet.Services {

   public class CompanyService : ICompanyService {

      private readonly AppDbContext _context;

      public CompanyService(AppDbContext context) {
         _context = context;
      }

      public async Task<IEnumerable<CompanyDTO>> GetCompaniesAsync() {
         var companies = await _context.Companies.ToListAsync();
         return companies.Select(c => c.MapToCompanyDTO());
      }

      public async Task<CompanyDTO> GetCompanyAsync(int id) {
         var company = await _context.Companies.FindAsync(id);
         return company?.MapToCompanyDTO();
      }

      public async Task<bool> UpdateCompanyAsync(int id, CompanyDTO companyDTO) {
         var existingCompany = await _context.Companies.FindAsync(id);

         if (existingCompany == null) {
            return false;
         }

         var updatedCompany = companyDTO.MapToCompany();
         existingCompany.UpdateFromDTO(updatedCompany);

         _context.Entry(existingCompany).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
            return true;
         }
         catch (DbUpdateConcurrencyException) {
            return CompanyExists(id);
         }
      }

      public async Task<(bool Success, string ErrorMessage, Company Company)> AddCompanyAsync(CompanyDTO companyDTO) {
         if (companyDTO == null) {
            return (false, "Please provide a valid company.", null);
         }

         if (_context.Companies == null) {
            return (false, "Entity set 'AppDbContext.Companies' is null.", null);
         }

         if (CompanyExistsByIDE(companyDTO.IDE)) {
            return (false, "A company with the same IDE already exists.", null);
         }

         ValidationContext validationContext = new ValidationContext(companyDTO);
         List<ValidationResult> validationResults = new List<ValidationResult>();
         bool isValid = Validator.TryValidateObject(companyDTO, validationContext, validationResults);

         if (!isValid) {
            throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
         }

         var newCompany = companyDTO.MapToCompany();

         _context.Companies.Add(newCompany);
         await _context.SaveChangesAsync();

         return (true, null, newCompany);
      }

      public async Task<bool> DeleteCompanyAsync(int id) {
         if (_context.Companies == null) {
            return false;
         }

         var company = await _context.Companies.FindAsync(id);
         if (company == null) {
            return false;
         }

         _context.Companies.Remove(company);
         await _context.SaveChangesAsync();

         return true;
      }

      private bool CompanyExists(int id) {
         return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
      }

      private bool CompanyExistsByIDE(string ide) {
         return _context.Companies?.Any(c => c.IDE == ide) ?? false;
      }

   }
}