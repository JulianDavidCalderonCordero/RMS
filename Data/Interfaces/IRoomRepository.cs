using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRoomRepository
    {
        public IEnumerable<RoomEntity> GetAvailableRooms();
        public IEnumerable<RoomEntity> GetRooms();
        public bool AddNewRoom(string name, int capacity, bool availability);
        public bool UpdateRoom(int id, string name, int capacity, bool availability);
        public bool RemoveRoom(int id);
        public bool CheckRoomAvailability(int id);
    }
}
