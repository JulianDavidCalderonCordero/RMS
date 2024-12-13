using Business.Interfaces;
using Data;
using Data.Interfaces;

namespace Business
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository) 
        {
            _repository = repository;
        }
        public bool AddNewRoom(string name, int capacity, bool availability)
        {
            return _repository.AddNewRoom(name, capacity, availability);
        }

        public IEnumerable<RoomEntity> GetAvailableRooms()
        {
            return _repository.GetAvailableRooms();
        }

        public IEnumerable<RoomEntity> GetRooms()
        {
            return _repository.GetRooms();
        }

        public bool RemoveRoom(int id)
        {
            return _repository.RemoveRoom(id);
        }

        public bool UpdateRoom(int id, string name, int capacity, bool availability)
        {
            return _repository.UpdateRoom(id, name, capacity, availability);
        }
    }
}
