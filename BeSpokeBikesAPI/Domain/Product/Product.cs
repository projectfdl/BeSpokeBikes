namespace BeSpokeBikesAPI
{
    public class Product
    {
        public int Id { get; set; }

        public string Name{ get; set; }

        public string Manufacturer { get; set; }

        public string Style { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SalePrice { get; set; }

        public int QuantityOnHand { get; set; }

        public decimal CommisionPercent { get; set; }
    }
}