using System.ComponentModel.DataAnnotations;

namespace AllTrailsAdmin.Models
{
    public class Trail
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Length (km)")]
        [Range(0.1, 28000)] // Trans Canada Trail
        [Required]
        public double Length { get; set; } // 7.9km

        [Display(Name = "Elevation Gain (m)")]
        [Range(0, 30000)] // Everest
        [Required]
        public int ElevationGain { get; set; } // 200m

        [Required]
        public string Location { get; set; } = string.Empty; // address, city, province... display Google map later

        // Url to image file stored in Azure Storage
        public string ImageUrl { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:MMM d, yyyy}")]
        [Display(Name = "Created")]
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now; // default to current timestamp
    }
}
