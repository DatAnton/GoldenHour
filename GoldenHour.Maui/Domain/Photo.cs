using SQLite;

namespace GoldenHour.Maui.Domain
{
    [Table("Photos")]
    public class Photo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IncidentId { get; set; }
        public string Path { get; set; }
    }
}
