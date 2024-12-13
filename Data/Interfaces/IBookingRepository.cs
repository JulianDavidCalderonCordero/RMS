using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IBookingRepository
    {
        public IEnumerable<BookingEntity> SearchBookings(DateTime? date, int? room_id);
        public IEnumerable<BookingEntity> GetBookings();
        public bool AddNewBooking(int room_id, DateTime date, string username);
        public bool UpdateBooking(int id, int room_id, DateTime date, string username);
        public bool CancelBooking(int id);
    }
}
