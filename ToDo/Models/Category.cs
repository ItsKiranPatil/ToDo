using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoDemo.Models
{
    [Table("Category")]
    public class Category
    {

        public int CategoryID { get; set; } 
            
        public string Name { get; set; }  = string.Empty;
    }
}
