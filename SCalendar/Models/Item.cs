using System;

namespace SCalendar.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int StartingDate { get; set; }
        public int EndingDate { get; set; }
        public int StartingTime { get; set; }
        public int EndingTime { get; set; }
        public int Color { get; set; }
    }
}
