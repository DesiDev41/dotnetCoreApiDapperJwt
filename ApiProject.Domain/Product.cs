namespace ApiProject.Domain
{
    public class Product
    {
        public int Id { set; get; }
        public string ProductName { set; get; }
        public string ProductSlug { set; get; }
        public string ProductDescription { set; get; }
        public string ProductImage { set; get; }
        public string ProductPrice { set; get; }
        public bool IsActive { set; get; }
    }
}