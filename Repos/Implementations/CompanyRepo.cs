using Microsoft.EntityFrameworkCore;
using ODataCoreDemo.Models;
using ODataCoreDemo.Repos.Interface;

namespace ODataCoreDemo.Repos.Implementations
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly ApiDbContext _context;

        public CompanyRepo(ApiDbContext context)
        {
            _context = context;
        }

        public void Create(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

        public IQueryable<Company> GetAll()
        {
           return _context.Companies.Include(a =>a.Products).AsQueryable();
        }

        public IQueryable<Company> GetById(int id)
        {
            return _context.Companies.Include(a => a.Products).AsQueryable().Where(c => c.ID == id);
        }

        public void Update(Company company)
        {
            _context.Companies
           .Update(company);
            _context.SaveChanges();
        }
    }
}
