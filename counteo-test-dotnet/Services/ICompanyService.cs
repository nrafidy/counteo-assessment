using counteo_test_dotnet.DTO;
using counteo_test_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace counteo_test_dotnet.Services {

   public interface ICompanyService {
      public Task<IEnumerable<CompanyDTO>> GetCompaniesAsync();

      public Task<CompanyDTO> GetCompanyAsync(int id);

      public Task<bool> UpdateCompanyAsync(int id, CompanyDTO companyDTO);

      public Task<(bool Success, string ErrorMessage, Company Company)> AddCompanyAsync(CompanyDTO companyDTO);

      public Task<bool> DeleteCompanyAsync(int id);
   }
}
