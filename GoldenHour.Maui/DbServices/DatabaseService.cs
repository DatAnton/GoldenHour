using GoldenHour.Maui.Domain;
using SQLite;

namespace GoldenHour.Maui.DbServices
{
    public class DatabaseService
    {
        private SQLiteConnection _connection;
        private string _dbPath;

        public DatabaseService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (_connection != null) { return; }
            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<Incident>();
            _connection.CreateTable<Photo>();
        }

        public void Clean()
        {
            Init();
            _connection.DeleteAll<Incident>();
            _connection.DeleteAll<Photo>();
        }

        public List<Incident> GetIncidents()
        {
            Init();
            return _connection.Table<Incident>().ToList();
        }

        public void AddIncident(Incident incident, List<Photo> photos) 
        {
            Init();
            _connection.Insert(incident);

            foreach (Photo photo in photos)
            {
                photo.IncidentId = incident.Id;
                _connection.Insert(photo);
            }
        }

        public List<Photo> GetPhotos(int incidentId) 
        {
            return _connection.Table<Photo>().Where(p => p.IncidentId == incidentId).ToList();
        }

        public void SetSuccessRequest(int incidentId, bool value)
        {
            Init();
            var incident = _connection.Table<Incident>()
                .FirstOrDefault(x => x.Id == incidentId);

            incident.IsSuccessfull = value;
            _connection.Update(incident);
        }
    }
}
