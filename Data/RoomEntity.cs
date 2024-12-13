using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class RoomEntity
    {
        public int id;
        [Required]
        public string name;
        [Required]
        public int capacity;
        public bool availability;
    }
}
