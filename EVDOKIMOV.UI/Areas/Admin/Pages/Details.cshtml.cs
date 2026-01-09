using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.UI;

namespace EVDOKIMOV.UI.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly EVDOKIMOV.UI.TempContext _context;

        public DetailsModel(EVDOKIMOV.UI.TempContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FirstOrDefaultAsync(m => m.Id == id);

            if (dish is not null)
            {
                Dish = dish;

                return Page();
            }

            return NotFound();
        }
    }
}
