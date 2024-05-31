using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MadunaFZ_Assign1.Models
{
    public class Event
    {
        // EF will instruct the database to automatically generate this value
        public int EventId { get; set; }

        [DisplayName("Title of the event")]
        [Required]
        public string EventTitle { get; set; }
        
        [DisplayName("Description")]
        [Required]
        public string EventDescription { get; set; }

        [DisplayName("Start Date")]
        [Required]
        public DateTime EventStartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EventEndDate { get; set; }

        [DisplayName("Location")]
        [Required]
        public string EventLocation { get; set; }

        [Required]
        public int EventMaxAttendees { get; set; }
        public int EventRegistrations { get; set; } = 0;

        //Navigation properties
        public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();

        public string Slug
        {
            get
            {
                if (EventTitle == null)
                    return "";
                else
                    return EventTitle.Replace(' ', '-');
            }
        }
    }
}
