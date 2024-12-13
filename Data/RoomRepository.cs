using Dapper;
using Data.Interfaces;
using System.Data;

namespace Data
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IConnection _connection;

        public RoomRepository(IConnection connection) 
        {
            _connection = connection;
        }
        public bool AddNewRoom(string name, int capacity, bool availability)
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("name", name);
                parameters.Add("capacity", capacity);
                parameters.Add("availability", availability);
                connection.Execute("addNewRoom", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public IEnumerable<RoomEntity> GetAvailableRooms()
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                IEnumerable<RoomEntity> rooms = connection.Query<RoomEntity>("getAvailableRooms", commandType: CommandType.StoredProcedure);
                return rooms.ToList();
            }
        }

        public IEnumerable<RoomEntity> GetRooms()
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                IEnumerable<RoomEntity> rooms = connection.Query<RoomEntity>("getRooms", commandType: CommandType.StoredProcedure);
                return rooms.ToList();
            }
        }

        public bool RemoveRoom(int id)
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", id);
                connection.Execute("removeRoom", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public bool UpdateRoom(int id, string name, int capacity, bool availability)
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", id);
                parameters.Add("name", name);
                parameters.Add("capacity", capacity);
                parameters.Add("availability", availability);
                connection.Execute("addNewRoom", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
        public bool CheckRoomAvailability(int id)
        {
            using (IDbConnection connection = _connection.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("id", id);
                bool availability = connection.QueryFirstOrDefault<bool>("checkRoomAvailability", parameters, commandType: CommandType.StoredProcedure);
                return availability;
            }
        }
    }
}
