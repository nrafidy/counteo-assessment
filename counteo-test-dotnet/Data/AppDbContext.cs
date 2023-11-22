using counteo_test_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace counteo_test_dotnet.Data {

   public class AppDbContext : DbContext {

      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
      }

      public DbSet<Company>? Companies { get; set; }
   }

}
