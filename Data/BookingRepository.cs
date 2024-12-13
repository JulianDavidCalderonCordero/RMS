using Dapper;
using Data.Interfaces;
using System.Data.Common;
using System.Data;

namespace Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IConnection _connection;

        public BookingRepository(IConnection connection)
        {
            _connection = connection;
        }
        public bool AddNewBooking(int room_id, DateTime date, string username)
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("room_id", room_id);
                parameters.Add("date", date);
                parameters.Add("username", username);
                connection.Execute("addNewBooking", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public bool CancelBooking(int id)
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", id);
                connection.Execute("cancelBooking", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public IEnumerable<BookingEntity> SearchBookings(DateTime? date, int? room_id)
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("date", date);
                parameters.Add("room_id", room_id);
                IEnumerable<BookingEntity> bookings = connection.Query<BookingEntity>("searchBooking", parameters, commandType: CommandType.StoredProcedure);
                return bookings;
            }
        }

        public IEnumerable<BookingEntity> GetBookings()
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                IEnumerable<BookingEntity> bookings = connection.Query<BookingEntity>("getBookings", commandType: CommandType.StoredProcedure);
                return bookings;
            }
        }

        public bool UpdateBooking(int id, int room_id, DateTime date, string username)
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", id);
                parameters.Add("room_id", room_id);
                parameters.Add("date", date);
                parameters.Add("username", username);
                connection.Execute("updateBooking", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
