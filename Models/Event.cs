using System.ComponentModel.DataAnnotations;

namespace FinalWebApplication.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
      
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public string Location { get; set; }
        public double Price { get; set; }
        public bool IsVip { get; set; }

        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }




    }
}




