using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class EditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Entry { get; set; }
    }
}