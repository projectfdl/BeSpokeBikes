namespace BeSpokeBikesAPI
{
    public class Salesperson
    {
        public int Id { get; set; }

        public string FirstName{ get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? TerminationDate { get; set; }

        public int? ManagerId { get; set; }

        public Salesperson? Manager { get; set; }
    }
}