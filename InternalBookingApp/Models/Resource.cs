//Creating a class that represents the resources (such as company car or boardroom) that can be booked
using System.ComponentModel.DataAnnotations;// this enables server-side validation

namespace InternalBookingApp.Models
{
    public class Resource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1")]
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; } = true;


        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
