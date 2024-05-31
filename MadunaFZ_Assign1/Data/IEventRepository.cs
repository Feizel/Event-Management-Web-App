using MadunaFZ_Assign1.Models;

namespace MadunaFZ_Assign1.Data
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int id);
        Event GetEventWithAttendees(int id);
        IEnumerable<Attendee> GetAttendeesForEvent(int eventId);
        void AddAttendee(Attendee newAttendeeRegistration);
        void SaveChanges();
    }
}
