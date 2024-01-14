namespace ParcNautic;
using ParcNautic.Models;

public partial class NauticZqEntryPage : ContentPage
{
	public NauticZqEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetNauticZqsAsync();
    }
    async void OnNauticZqAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NauticZqPage
        {
            BindingContext = new NauticZq()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new NauticZqPage
            {
                BindingContext = e.SelectedItem as NauticZq
            });
        }
    }
}