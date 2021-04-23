using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.Data.Models
{
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TodoId { get; set; }

        [StringLength(50, ErrorMessage = "Your title cannot be more than 50 characters")]
        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "E-mail Address")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdded => DateTime.Now;

        [Display(Name = "Due Date")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DueDate { get; set; }

        public Boolean Completed { get; set; } = false;

        [Display(Name = "Date of Completion")]
        [DataType(DataType.DateTime)]
        public DateTime? DateCompleted { get; set; }
    }
}
