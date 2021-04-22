using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todos.Data;
using Todos.Data.Models;

namespace Todos.Pages.Admin.TodoPages
{
    public class DetailsModel : PageModel
    {
        private readonly Todos.Data.TodoDbContext _context;

        public DetailsModel(Todos.Data.TodoDbContext context)
        {
            _context = context;
        }

        public Todo Todo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = await _context.Todos.FirstOrDefaultAsync(m => m.TodoId == id);

            if (Todo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
