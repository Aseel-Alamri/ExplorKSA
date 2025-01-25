namespace FinalWebApplication.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsAvailable{ get; set; }
        public List<Event> Events { get; set; }
    }

}
