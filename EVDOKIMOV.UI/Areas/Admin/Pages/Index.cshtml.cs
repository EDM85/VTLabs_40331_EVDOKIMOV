using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.UI;
using EVDOKIMOV.UI.Services.ProductService;

namespace EVDOKIMOV.UI.Areas.Admin.Pages
{
    public class IndexModel(IProductService productService) : PageModel
    {
        // private readonly EVDOKIMOV.UI.TempContext _context;

        //public IndexModel(IProductService productService)
        //{
        //    _context = context;
        //}

        public IList<Dish> Dish { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Dish = (await productService.GetProductListAsync(null)).Data;
        }
    }
}
