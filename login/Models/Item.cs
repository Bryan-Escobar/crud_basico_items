namespace login.Models
{
    public class Item
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? SerialNumberId { get; set; }

        public SerialNumber? SerialNumber { get; set; }
    }
    // /items/overview
}
