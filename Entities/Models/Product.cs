namespace Entities.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID {  get; set; }
        public Category Category { get; set; }

    }
}
