using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Data;
using Todos.Data.Models;

namespace Todos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TodoDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, TodoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Todo> Todos { get; set; }
        public List<Todo> TodosCompletedLastDay { get; set; } = new List<Todo>();
        public List<Todo> TodosToBeCompletedToday { get; set; } = new List<Todo>();

        public async Task OnGetAsync()
        {
            Todos = await _context.Todos.ToListAsync();
            foreach(var todo in Todos)
            {
                if (todo.DateCompleted != null && todo.DateCompleted > DateTime.Now.AddHours(-24) && todo.DateCompleted <= DateTime.Now)
                {
                    TodosCompletedLastDay.Add(todo);
                } else if (todo.DateCompleted == null && todo.DueDate > DateTime.Now && todo.DueDate <=DateTime.Now.AddHours(24))
                {
                    TodosToBeCompletedToday.Add(todo);
                }
            }
        }
    }
}
