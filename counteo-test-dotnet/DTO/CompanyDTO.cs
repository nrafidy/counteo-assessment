using System.ComponentModel.DataAnnotations;

namespace counteo_test_dotnet.DTO {

   public class CompanyDTO {

      public int Id { get; set; }

      [Required(ErrorMessage = "IDE Cannot be blank")]
      [StringLength(12, MinimumLength = 12, ErrorMessage = "The IDE must be exactly 12 characters long.")]
      public string? IDE { get; set; }

      [Required(ErrorMessage = "Name Cannot be blank")]
      public string? Nom { get; set; }

      [Required(ErrorMessage = "Address Cannot be blank")]
      public string? Adresse { get; set; }

      [Required(ErrorMessage = "Legal Form Cannot be blank")]
      public string? FormeJuridique { get; set; }

      [Required(ErrorMessage = "HQ Cannot be blank")]
      public string? Siege { get; set; }

      [Required(ErrorMessage = "Date Cannot be blank")]
      public string? DateDerniereModification { get; set; }
   }

}
