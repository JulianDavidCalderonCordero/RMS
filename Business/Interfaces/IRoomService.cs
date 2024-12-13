using Data;

namespace Business.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<RoomEntity> GetAvailableRooms();
        IEnumerable<RoomEntity> GetRooms();
        bool AddNewRoom(string name, int capacity, bool availability);
        bool UpdateRoom(int id, string name, int capacity, bool availability);
        bool RemoveRoom(int id);
    }
}
