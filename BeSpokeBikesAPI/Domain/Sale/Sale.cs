namespace BeSpokeBikesAPI
{
    public class Sale
    {
        public int Id { get; set; }

        public int CustomerId{ get; set; }

        public int SalespersonId { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal CommissionPercent { get; set; }

        public Customer Customer { get; set; }

        public Salesperson Salesperson { get; set; }

        public Product Product { get; set; }
    }
}