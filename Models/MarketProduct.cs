namespace Models
{
    public class MarketProduct : Identity
    {
        public int MarketId { get; set; }

        public Market Market { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
