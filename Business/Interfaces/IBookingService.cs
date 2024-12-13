using Data;

namespace Business.Interfaces
{
    public interface IBookingService
    {
        public IEnumerable<BookingEntity> SearchBookings(DateTime? date, int? room_id);
        public IEnumerable<BookingEntity> GetBookings();
        public bool AddNewBooking(int room_id, DateTime date, string username);
        public bool UpdateBooking(int id, int room_id, DateTime date, string username);
        public bool CancelBooking(int id);
    }
}
