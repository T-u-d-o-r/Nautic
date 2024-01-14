using ParcNautic.Models;
namespace ParcNautic;

public partial class PlanEntryPage : ContentPage
{
	public PlanEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetNauticPlanAsync();
    }
    async void OnNauticPlanClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PlanPage
        {
            BindingContext = new NauticPlan()
        });
    }
    async void OnPlanViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new PlanPage
            {
                BindingContext = e.SelectedItem as NauticPlan
            });
        }
    }
}