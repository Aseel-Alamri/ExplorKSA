using System.ComponentModel.DataAnnotations;

namespace FinalWebApplication.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String City { get; set; }
        public String Address { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public int EventId { get; set; }  //Foreign Key 

    }
}
