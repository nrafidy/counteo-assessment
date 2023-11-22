using counteo_test_dotnet.Data;
using counteo_test_dotnet.Services;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(
   builder.Configuration.GetConnectionString("CounteoDb")));

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICompanyService, CompanyService>();


builder.Services.AddCors(options => {
   options.AddPolicy(name: MyAllowSpecificOrigins,
                     policy => {
                        policy.WithOrigins("*")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
   app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
