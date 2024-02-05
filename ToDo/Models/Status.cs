using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoDemo.Models
{
    [Table("Status")]
    public class Status
    {
        public int StatusID { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
