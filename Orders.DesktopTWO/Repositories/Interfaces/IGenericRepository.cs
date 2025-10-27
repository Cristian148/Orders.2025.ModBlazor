using Orders.Shared.DTOs;
using Orders.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DesktopTWO.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

        //Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

        Task<ActionResponse<T>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<T>>> GetAsync();

        Task<ActionResponse<T>> AddAsync(T entity);

        Task<ActionResponse<T>> DeleteAsync(int id);

        Task<ActionResponse<T>> UpdateAsync(T entity);
    }
}
