using System.ComponentModel.DataAnnotations;

namespace AllTrailsAdmin.Models
{
    public class Category
    {
        // db primary key
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
