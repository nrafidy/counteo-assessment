using System.ComponentModel.DataAnnotations;

namespace counteo_test_dotnet.Models {

   public class Company {
      //[Key]
      public int Id { get; set; }

      //[Required]
      public string? IDE { get; set; }

      //[Required]
      public string? Nom { get; set; }

      //[Required]
      public string? Adresse { get; set; }

      //[Required]
      public string? FormeJuridique { get; set; }

      //[Required]
      public string? Siege { get; set; }

      public DateTime? DateDerniereModification { get; set; }

      public void UpdateFromDTO(Company companyDTO) {
         Nom = companyDTO.Nom;
         Adresse = companyDTO.Adresse;
         FormeJuridique = companyDTO.FormeJuridique;
         Siege = companyDTO.Siege;
         DateDerniereModification = companyDTO.DateDerniereModification;
      }
   }

}
