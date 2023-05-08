using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataCoreDemo;
using ODataCoreDemo.Models;
using ODataCoreDemo.Repos.Implementations;
using ODataCoreDemo.Repos.Interface;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Company>("Companies");
    return builder.GetEdmModel();
}



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(options => options
    .AddRouteComponents("odata",GetEdmModel())
    .Select()
    .Filter()
    .OrderBy()
    .SetMaxTop(20)
    .Count()
    .Expand()
    );

builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "CompaniesDB"));
builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
var app = builder.Build();
 DBSeeder.AddCompaniesData(app);

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
