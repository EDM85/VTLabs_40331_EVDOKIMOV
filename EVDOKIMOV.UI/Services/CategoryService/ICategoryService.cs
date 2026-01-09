using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.Domain.Models;

namespace EVDOKIMOV.UI.Services.CategoryService
{
    public interface ICategoryService
    {
        /// <summary>
        /// получение списка всех категорий
        /// </summary>
        /// <returns></returns>
        public Task<ResponseData<List<Category>>> GetCategoryListAsync();
    }
}
