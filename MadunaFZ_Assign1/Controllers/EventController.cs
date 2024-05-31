using MadunaFZ_Assign1.Data;
using MadunaFZ_Assign1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MadunaFZ_Assign1.Controllers
{
    [Authorize(Roles = "Attendee, Admin")]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepo;

        public EventController(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var events = _eventRepo.GetAllEvents()
                .OrderBy(e => e.EventStartDate);
            return View(events);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var Event = _eventRepo.GetEventById(id);
            if(Event == null)
            {
                return NotFound();
            }

            return View(Event);

        }
    }
}
