using GoldenHour.Maui.Pages;

namespace GoldenHour.Maui.Helpers
{
    public class TabsBuilder
    {
        public void BuildNavTabs()
        {
            Shell.Current.Items.Clear();

            var role = App.UserInfo?.Role;

            var tabs = new TabBar
            {
                Items =
                {
                    new Tab
                    {
                        Title = "Me",
                        Icon = "user.png", 
                        Items =
                        {
                            new ShellContent
                            {
                                ContentTemplate = new DataTemplate(typeof(MainPage))
                            }
                        }
                    }
                }
            };

            if (role == Constants.MEDIC_ROLE_NAME)
            {
                tabs.Items.Add(new Tab
                {
                    Title = "New Incident",
                    Icon = "accident.png",
                    Items = 
                    {
                        new ShellContent
                        {
                            ContentTemplate = new DataTemplate(typeof(NewIncidentPage))
                        }
                    }
                });

                tabs.Items.Add(new Tab
                {
                    Title = "History",
                    Icon = "history.png",
                    Items =
                    {
                        new ShellContent
                        {
                            ContentTemplate = new DataTemplate(typeof(HistoryPage))
                        }
                    }
                });
            }

            if (!Shell.Current.Items.Contains(tabs))
            {
                Shell.Current.Items.Add(tabs);
            }

        }
    }
}
