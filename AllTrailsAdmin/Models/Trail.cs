namespace AllTrailsAdmin.Models
{
    public class Trail
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Length { get; set; } // 7.9km

        public int ElevationGain { get; set; } // 200m

        public string Location { get; set; } = string.Empty; // address, city, province... display Google map later

        public DateTime CreatedDate { get; set; } = DateTime.Now; // default to current timestamp
    }
}
