namespace FinalWebApplication.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int NumberOfPersons { get; set; }
        public DateTime SelectedDate { get; set; }
        public List<Hotel> NearbyHotels { get; set; }
    }

}
