namespace Marketplace.Models.ProductData
{
    public class ProductOffer : Identity
    {
        public Market Market { get; set; }

        public Product Product { get; set; }

        public decimal Price { get; set; }
    }
}