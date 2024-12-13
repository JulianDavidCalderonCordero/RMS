using Business.Interfaces;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class RoomsModel : PageModel
    {
        [BindProperty]
        public RoomEntity Room { get; set; }
        public IEnumerable<RoomEntity> Rooms { get; set; }
        private readonly IRoomService _service;
        public RoomsModel (IRoomService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            Rooms = _service.GetRooms();
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                _service.AddNewRoom(Room.name, Room.capacity, Room.availability);
                Rooms = _service.GetRooms();
            }
            Page();
        }

        public void OnPostDelete(int id)
        {
            _service.RemoveRoom(id);
            Rooms = _service.GetRooms();
            RedirectToPage();
        }
    }
}
