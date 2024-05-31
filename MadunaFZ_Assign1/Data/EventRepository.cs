using MadunaFZ_Assign1.Models;
using Microsoft.EntityFrameworkCore;

namespace MadunaFZ_Assign1.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly EntityDbContext _dbContext;
        public EventRepository(EntityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddAttendee(Attendee newAttendeeRegistration)
        {
            _dbContext.Attendees.Add(newAttendeeRegistration);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _dbContext.Events;
        }

        public IEnumerable<Attendee> GetAttendeesForEvent(int eventId)
        {
            return _dbContext.Attendees.Where(a => a.EventId == eventId).ToList();

        }

        public Event GetEventById(int id)
        {
            return _dbContext.Events.FirstOrDefault(e => e.EventId == id);
        }

        public Event GetEventWithAttendees(int id)
        {
            return _dbContext.Events
                .Include(e => e.Attendees)
                .FirstOrDefault(e => e.EventId == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
