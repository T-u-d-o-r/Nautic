using ParcNautic.Models;
using Plugin.LocalNotification;

namespace ParcNautic;

public partial class PlanPage : ContentPage
{
	public PlanPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (NauticPlan)BindingContext;
        NauticZq selectedNauticZq = (NauticZqPicker.SelectedItem as NauticZq);
        slist.NauticZqId = selectedNauticZq.Id;
        await App.Database.SaveNauticPlanAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (NauticPlan)BindingContext;
        await App.Database.DeleteNauticPlanAsync(slist);
        await Navigation.PopAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetNauticZqsAsync();
        NauticZqPicker.ItemsSource = (System.Collections.IList)items;
        NauticZqPicker.ItemDisplayBinding = new Binding("NauticZqDetails");

        var NauticZql = (NauticPlan)BindingContext;

    }
    private void ScheduleNotification(NauticPlan NauticPlan)
    {
        DateTime notifyTime = NauticPlan.BeginDate.AddDays(-2);
        var request = new NotificationRequest
        {
            Title = "Reminder: Activitate!",
            Description = $"Nu uita, activitatea incepe {NauticPlan.BeginDate.ToShortDateString()}",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = notifyTime
            }
        };

        LocalNotificationCenter.Current.Show(request);
    }
    }