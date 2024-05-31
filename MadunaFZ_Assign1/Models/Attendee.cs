using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MadunaFZ_Assign1.Models
{
    public class Attendee
    {
        // EF will instruct the database to automatically generate this value
        public int AttendeeId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [DisplayName("Name")]
        public string AttendeeName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address.")]
        [DisplayName("Email")]
        public string AttendeeEmail { get; set; }

        //Foreign Key
        [Required]
        public int EventId { get; set; }  // foreign key property

        //Navigation properties
        public Event Event { get; set; }
    }
}
