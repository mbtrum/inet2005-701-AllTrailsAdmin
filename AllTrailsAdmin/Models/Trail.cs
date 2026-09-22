namespace AllTrailsAdmin.Models
{
    public class Trail
    {
        public int Id { get; set; } // unique id

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
                
        public int Length { get; set; } // metres 1000m 

        public int ElevationGain { get; set; } // metres 1000m

        public string Difficulty { get; set; } = string.Empty; // easy/medium/har

        public double EstimatedHours { get; set; } // 1.5hr

        public string Location { get; set; } = string.Empty; // display on Google map

        public string ImageFilename {  get; set; } = string.Empty; // the related picture e.g. capebreton.jpg

        public DateTime CreatedDate { get; set; } = DateTime.Now;
      
    }
}
