using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.UI.Services.CategoryService;
using EVDOKIMOV.UI.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace EVDOKIMOV.UI.Controllers
{
    public class ProductController(ICategoryService categoryService, IProductService productService) : Controller
    {
        public async Task<IActionResult> Index(string? category)
        {
            // получение списка категорий
            ViewData["Categories"] = categoryService.GetCategoryListAsync().Result.Data; 
            ViewData["CurrentCategory"] = String.IsNullOrEmpty(category)
                ? "Все"
                : category;

            var productResponse = await productService.GetProductListAsync(category);
              
            if (!productResponse.Success) { return NotFound(productResponse.ErrorMessage); }
            
            return View(productResponse.Data);
        }
    }
}
