using Business.Interfaces;
using Data;
using Data.Interfaces;

namespace Business
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository) 
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }

        public bool AddNewBooking(int room_id, DateTime date, string username)
        {
            bool isRoomAvailable = _roomRepository.CheckRoomAvailability(room_id);
            if (isRoomAvailable)
            {
                return _bookingRepository.AddNewBooking(room_id, date, username);
            }
            else
            {
                return false;
            }
        }

        public bool CancelBooking(int id)
        {
            return _bookingRepository.CancelBooking(id);
        }

        public IEnumerable<BookingEntity> SearchBookings(DateTime? date, int? room_id)
        {
            return _bookingRepository.SearchBookings(date, room_id);
        }

        public IEnumerable<BookingEntity> GetBookings()
        {
            return _bookingRepository.GetBookings();
        }

        public bool UpdateBooking(int id, int room_id, DateTime date, string username)
        {
            return _bookingRepository.UpdateBooking(id, room_id, date, username);
        }
    }
}
