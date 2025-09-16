using Microsoft.AspNetCore.Mvc;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.DTOs;
using Orders.Shared.Entites;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : GenericController<Country>
{
    
    private readonly ICountriesUnitOfWork _countriesUnitOfWork;
    public CountriesController(IGenericUnitOfWork<Country> unit, ICountriesUnitOfWork countriesUnitOfWork) : base(unit)
    {
        _countriesUnitOfWork = countriesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _countriesUnitOfWork.GetAsync(pagination);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _countriesUnitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _countriesUnitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }

}




//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Orders.Backend.Data;
//using Orders.Shared.Entites;

//namespace Orders.Backend.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]

//    public class CountriesController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public CountriesController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAsync()
//        {
//            return Ok(await _context.Countries.ToListAsync());
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetAsync(int id)
//        {
//            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
//            if (country == null)
//            {
//                return NotFound();
//            }

//            return Ok(country);
//        }

//        [HttpPost]
//        public async Task<IActionResult> PostAsync(Country country)
//        {
//            _context.Add(country);
//            await _context.SaveChangesAsync();
//            return Ok(country);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAsync(int id)
//        {
//            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
//            if (country == null)
//            {
//                return NotFound();
//            }

//            _context.Remove(country);
//            await _context.SaveChangesAsync();
//            return NoContent();
//        }

//        [HttpPut]
//        public async Task<IActionResult> PutAsync(Country country)
//        {
//            _context.Update(country);
//            await _context.SaveChangesAsync();
//            return Ok(country);
//        }

//    }
//}
