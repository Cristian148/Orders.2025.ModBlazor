using Microsoft.EntityFrameworkCore;
using Orders.DesktopTWO.Data;
using Orders.DesktopTWO.Repositories.Interfaces;
using Orders.Shared.DTOs;
using Orders.Shared.Entites;
using Orders.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DesktopTWO.Repositories.Implementations
{
    public class CategoriesRepository : GenericRepository<Category>,ICategoriesRepository
    {
        private readonly DataContext _context;

        public CategoriesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Category>>> GetAsync()
        {
            var queryable = _context.Categories.AsQueryable();

            queryable = queryable.Where(x => x.Name.ToLower().Contains("al"));

            return new ActionResponse<IEnumerable<Category>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Name)
                    .ToListAsync()
            };
        }
    }
}
