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
    public class IndexModel : PageModel
    {
        private readonly Todos.Data.TodoDbContext _context;

        public IndexModel(Todos.Data.TodoDbContext context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; }

        public async Task OnGetAsync()
        {
            Todo = await _context.Todos.ToListAsync();
        }

    }
}
