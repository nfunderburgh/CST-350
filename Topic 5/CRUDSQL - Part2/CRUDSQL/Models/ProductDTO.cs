namespace CRUDSQL.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PriceString { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public decimal Tax { get; set; }
    }
}
