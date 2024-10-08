using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoPizzaRazor.Data;
using ContosoPizzaRazor.Models;

namespace ContosoPizzaRazor.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoPizzaRazor.Data.ContosoPizzaContext _context;

        public DetailsModel(ContosoPizzaRazor.Data.ContosoPizzaContext context)
        {
            _context = context;
        }

        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }
    }
}
