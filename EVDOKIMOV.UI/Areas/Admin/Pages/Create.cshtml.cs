using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.UI.Services.ProductService;
using EVDOKIMOV.UI.Services.CategoryService;

namespace EVDOKIMOV.UI.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public CreateModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public SelectList Categories { get; set; } = default!;

        [BindProperty]
        public Dish Dish { get; set; } = new();

        [BindProperty]
        public IFormFile? ImageFile { get; set; } // <-- ДОБАВЛЕНО для загрузки файла

        public async Task OnGetAsync()
        {
            // получаем категории через сервис API
            var categoriesResponse = await _categoryService.GetCategoryListAsync();
            Categories = new SelectList(categoriesResponse.Data, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // перезагружаем список категорий при ошибке валидации
                var categoriesResponse = await _categoryService.GetCategoryListAsync();
                Categories = new SelectList(categoriesResponse.Data, "Id", "Name");
                return Page();
            }

            // отправляем данные через API сервис
            var result = await _productService.CreateProductAsync(Dish, ImageFile);

            if (result.Success)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError("", result.ErrorMessage);
                var categoriesResponse = await _categoryService.GetCategoryListAsync();
                Categories = new SelectList(categoriesResponse.Data, "Id", "Name");
                return Page();
            }
        }
    }
}