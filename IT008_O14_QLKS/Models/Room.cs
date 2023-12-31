using System.Collections.Generic;

namespace IT008_O14_QLKS.Models
{
    public class Room
    {
        public List<string> room = new List<string>();
        public Room()
        {
            
        }
        public Room(string roomid)
        {
            room.Add(roomid);
        }
    }
}