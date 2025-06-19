﻿namespace SignalR.EntityLayer.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string BookingName { get; set; }
        public string BookingPhone { get; set; }
        public string BookingEmail { get; set; }
        public int BookingPersonCount { get; set; } 
        public DateTime BookingDate { get; set; }

    }
}
