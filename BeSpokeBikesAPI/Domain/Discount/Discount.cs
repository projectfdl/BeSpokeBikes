namespace BeSpokeBikesAPI
{
    public class Discount
    {
        public int Id { get; set; }

        public string Description{ get; set; }

        public int ProductId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal? DiscountPercent { get; set; }

        public decimal? DiscountAmount { get; set; }
    }
}