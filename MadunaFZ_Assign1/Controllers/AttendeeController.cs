using MadunaFZ_Assign1.Data;
using MadunaFZ_Assign1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MadunaFZ_Assign1.Controllers
{
    //[Authorize(Roles = "Attendee")]
    public class AttendeeController : Controller
    {
        private readonly IEventRepository _eventRepo;

        public AttendeeController(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult List(int id)
        {
            var AttendeesForEvent = _eventRepo.GetAttendeesForEvent(id);

            return View(AttendeesForEvent);
        }

        [HttpGet]
        //[Authorize(Roles = "Attendee")]
        public IActionResult Register(int id)
        {
            var eventDetails = _eventRepo.GetEventById(id);
            if(eventDetails == null)
            {
                return NotFound();
            }

            var registration = new Attendee
            {
                EventId = id
            }; 

            return View(registration);
        }


        [HttpPost]
        //[Authorize(Roles = "Attendee")]
        public IActionResult Register(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Event = _eventRepo.GetEventById(attendee.EventId);
                    if (Event != null)
                    {
                        Event.EventRegistrations++;
                    }

                    _eventRepo.AddAttendee(attendee);
                    _eventRepo.SaveChanges();

                    return RedirectToAction("Confirmation", new { id = attendee.EventId});
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
   
            return View(attendee);
        }
        public IActionResult Confirmation(int id)
        {
            var myEvent = _eventRepo.GetEventWithAttendees(id);
            if (myEvent == null)
            {
                return NotFound();
            }
            return View(myEvent);
        }
    }
}
