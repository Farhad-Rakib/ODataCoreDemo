using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using ODataCoreDemo.Models;
using ODataCoreDemo.Repos.Interface;

namespace ODataCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepo _repo;

        public CompaniesController(ICompanyRepo repo)
        {
            _repo = repo;
        }

        [EnableQuery(PageSize = 3)]
        [HttpGet]
        public IQueryable<Company> Get()
        {
            return _repo.GetAll();
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public SingleResult<Company> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_repo.GetById(key));
        }


    }
}
