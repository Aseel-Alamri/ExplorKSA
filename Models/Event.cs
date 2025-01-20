using System.ComponentModel.DataAnnotations;

namespace FinalWebApplication.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String City { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }




    }
}
