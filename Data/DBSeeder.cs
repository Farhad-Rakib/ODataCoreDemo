using ODataCoreDemo;
using ODataCoreDemo.Models;

public class DBSeeder
{

    public static void AddCompaniesData(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetService<ApiDbContext>();
        db.Companies.Add(
            new Company()
            {
                ID = 1,
                Name = "Company A",
                Size = 25
            });
        //more companies here...

        db.Products.Add(
            new Product()
            {
                ID = 1,
                CompanyID = 1,
                Name = "Product A",
                Price = 10
            });
        //more products here..
        db.SaveChanges();
    }

}