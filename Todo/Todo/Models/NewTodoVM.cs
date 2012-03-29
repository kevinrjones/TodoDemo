using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Todo.Models
{
    public class NewTodoVM : IValidatableObject
    {
        [Required]
        public string Title { get; set; }
        public string Entry { get; set; }
        [Remote("ValidateExtension", "Validation", HttpMethod = "POST", ErrorMessage = "Invalid Extension", AdditionalFields = "Title, Entry")]
        public string File { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (File != null)
            {
                string ext = File.Split('.').Last();
                if (ext != "png")
                {
                    yield return new ValidationResult("Invalid extension", new[]{"File"});
                }
            }

        }
    }
}