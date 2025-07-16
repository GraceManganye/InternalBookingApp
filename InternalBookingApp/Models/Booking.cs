//Creating a class that represents bookings for a resource
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;// controls how class connects to database

namespace InternalBookingApp.Models
{
    public class Booking : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public int ResourceId { get; set; }

        [ForeignKey("ResourceId")]
        public Resource? Resource { get; set; }

        [Required(ErrorMessage = "Start time is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Booked By is required")]
        public required string BookedBy { get; set; }

        [Required(ErrorMessage = "Purpose for booking is required")]
        public required string Purpose { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndTime <= StartTime)
            {
                yield return new ValidationResult(
                    "End time must be after start time.",
                    new[] { nameof(EndTime) }
                );
            }
        }
    }
}
