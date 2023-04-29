namespace GoldenHour.Domain
{
    public class BloodGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }
        public List<ServiceMan> ServiceMen { get; set;}
    }
}
