using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoDemo.Models
{
    [Table("ToDo")]
    public class ToDo
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter a Description.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter a due date.")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }

        public Category? Category { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public int StatusID { get; set; }

        public Status? Status { get; set; }

    }
}
