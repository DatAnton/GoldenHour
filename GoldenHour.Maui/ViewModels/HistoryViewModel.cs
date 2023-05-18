using CommunityToolkit.Mvvm.Input;
using GoldenHour.Maui.Managers;
using System.Collections.ObjectModel;

namespace GoldenHour.Maui.ViewModels
{
    public partial class HistoryViewModel : BaseViewModel
    {
        private readonly IncidentManager _incidentManager;

        public HistoryViewModel(IncidentManager incidentManager)
        {
            _incidentManager = incidentManager;
        }

        public ObservableCollection<Domain.Incident> Incidents { get; set; } = new ObservableCollection<Domain.Incident>();

        [RelayCommand]
        async Task ResendAll()
        {
            await Shell.Current.DisplayAlert("Info", "All failed incidents will be resended now", "Ok");
            Task.Run(() => { 
                _incidentManager.SendAllUnsuccessfullIncidents(Incidents.Where(i => !i.IsSuccessfull).ToList()).Wait();
                LoadIncidents();
            });
        }

        public void LoadIncidents()
        {
            Incidents.Clear();
            var incidents = App.DbService.GetIncidents();
            foreach (var incident in incidents)
            {
                incident.DateTimeFormat = incident.DateTime.ToString("dd.MM.yyyy HH:mm");
                incident.BackgroundColor = incident.IsSuccessfull ? Colors.Green : Colors.Red;
                Incidents.Add(incident);
            }
        }
    }
}
