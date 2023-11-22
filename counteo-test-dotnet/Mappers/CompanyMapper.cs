using counteo_test_dotnet.DTO;
using counteo_test_dotnet.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace counteo_test_dotnet.Mappers {

   public static class CompanyMapper {

      public static Company MapToCompany(this CompanyDTO companyDTO) {
         return new Company {
            Id = companyDTO.Id,
            IDE = companyDTO.IDE,
            Nom = companyDTO.Nom,
            Adresse = companyDTO.Adresse,
            FormeJuridique = companyDTO.FormeJuridique,
            Siege = companyDTO.Siege,
            DateDerniereModification = System.DateTime.Parse(companyDTO.DateDerniereModification)
         };
      }

      public static CompanyDTO MapToCompanyDTO(this Company company) {
         return new CompanyDTO {
            Id = company.Id,
            IDE = company.IDE,
            Nom = company.Nom,
            Adresse = company.Adresse,
            FormeJuridique = company.FormeJuridique,
            Siege = company.Siege,
            DateDerniereModification = company.DateDerniereModification.ToString()
         };
      }
   }
}
