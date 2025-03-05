using System.ComponentModel.DataAnnotations.Schema;

namespace login.Models
{
    public class SerialNumber
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item? Item { get; set; }
    }
}
