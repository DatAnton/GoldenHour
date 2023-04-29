namespace GoldenHour.Domain
{
    public class Brigade
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Department { get; set; }
        public List<ServiceMan> ServiceMen { get; set; }
    }
}
