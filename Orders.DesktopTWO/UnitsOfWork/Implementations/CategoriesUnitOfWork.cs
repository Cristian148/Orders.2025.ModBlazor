using Orders.DesktopTWO.Repositories.Interfaces;
using Orders.DesktopTWO.UnitsOfWork.Interfaces;
using Orders.Shared.DTOs;
using Orders.Shared.Entites;
using Orders.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DesktopTWO.UnitsOfWork.Implementations
{
    public class CategoriesUnitOfWork : GenericUnitOfWork<Category>, ICategoriesUnitOfWork
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesUnitOfWork(IGenericRepository<Category> repository, ICategoriesRepository categoriesRepository) : base(repository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Category>>> GetAsync() => await _categoriesRepository.GetAsync();


    }
}
