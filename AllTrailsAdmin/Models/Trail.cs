namespace AllTrailsAdmin.Models
{
    public class Trail
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
                
        public int Length { get; set; } // metres 1000m 

        public int ElevationGain { get; set; } // metres 1000m
    }
}
