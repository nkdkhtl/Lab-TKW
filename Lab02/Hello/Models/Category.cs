namespace Hello.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //1-n vs Product
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
