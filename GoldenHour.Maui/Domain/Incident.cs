using SQLite;

namespace GoldenHour.Maui.Domain
{
    [Table("Incidents")]
    public class Incident
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ServiceManId { get; set; }
        public string ServiceManNickName { get; set; }
        public DateTime DateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Comment { get; set; }
        public string MedicId { get; set; }
        public bool IsSuccessfull { get; set; }
        [Ignore]
        public string DateTimeFormat { get; set; }
        [Ignore]
        public Color BackgroundColor { get; set; }
    }
}
