using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AllTrailsAdmin.Models
{
    public class Category
    {
        // primary key
        public int Id { get; set; }

        // navigation property
        [ValidateNever]
        public List<Trail> Trails { get; set; } = new List<Trail>();

        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
