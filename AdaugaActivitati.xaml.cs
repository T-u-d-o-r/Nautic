using ParcNautic.Models;
using Microsoft.Maui.Devices.Sensors;

namespace ParcNautic;

public partial class NauticZqPage : ContentPage
{
    public NauticZqPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var NauticZq = (NauticZq)BindingContext;
        await App.Database.SaveNauticZqAsync(NauticZq);
        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var NauticZq = (NauticZq)BindingContext;
        var Address = NauticZq.Address;
        var locations = await Geocoding.GetLocationsAsync(Address);

        var options = new MapLaunchOptions
        {
            Name = "PRO"
        };
        var location = locations?.FirstOrDefault();
        var myLocation = new Location(47.102726, 23.560380);
        await Map.OpenAsync(location, options);
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var NauticZq = (NauticZq)BindingContext;
        await App.Database.DeleteNauticZqAsync(NauticZq);
        await Navigation.PopAsync();
    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        string selectedItem = (string)picker.SelectedItem;

        // Coordonate
        if (selectedItem != null)
        {
            CoordinatesEditor.Text = "80.5033581, -67.0038175";
        }
    }


}