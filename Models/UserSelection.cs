﻿using System.ComponentModel.DataAnnotations;

namespace FinalWebApplication.Models
{
    public class UserSelection
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }
        public int NumberOfPeople { get; set; }
        public bool IsVIP { get; set; }
        public decimal TotalPrice { get; set; }
        // Add the EventDate property
        public DateTime EventDate { get; set; }
    }
}
