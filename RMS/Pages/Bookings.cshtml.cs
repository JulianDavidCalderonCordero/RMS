using Business.Interfaces;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages
{
    public class BookingsModel : PageModel
    {
        [BindProperty]
        public BookingEntity Booking { get; set; }
        public IEnumerable<BookingEntity> Bookings { get; set; }
        public IEnumerable<SelectListItem> Rooms { get; set; }
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        public BookingsModel(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }
        public void OnGet()
        {
            Bookings = _bookingService.GetBookings();
            Rooms = _roomService.GetRooms().Select(r => new SelectListItem
            {
                Value = r.id.ToString(),
                Text = r.name
            });
        }

        public void OnPost()
        {
            if(ModelState.IsValid)
            {
                _bookingService.AddNewBooking(Booking.room_id, Booking.date, Booking.username);
                Bookings = _bookingService.GetBookings();
            }
            Page();
        }

        public void OnPostDelete(int id)
        {
            _bookingService.CancelBooking(id);
            Bookings = _bookingService.GetBookings();
            Rooms = _roomService.GetRooms().Select(r => new SelectListItem
            {
                Value = r.id.ToString(),
                Text = r.name
            });
            Page();
        }
    }
}
