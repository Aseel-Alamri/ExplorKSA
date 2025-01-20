using System.ComponentModel.DataAnnotations;

namespace FinalWebApplication.Models
{
    public class UserSelection
    {
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; } //Foreign Key

        public int HotelId { get; set; } //Foreign Key

    }
}
