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
    public class IndexModel : PageModel
    {
        private readonly ContosoPizzaRazor.Data.ContosoPizzaContext _context;

        public IndexModel(ContosoPizzaRazor.Data.ContosoPizzaContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
        }
    }
}
