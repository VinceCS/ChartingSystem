using Library.ChartingSystem.Services;
using Maui.ChartingSystem.ViewModels;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace Maui.ChartingSystem
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void AddPatient(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Patient?patientId=0");
        }

        private void AddPhysician(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Physician?physicianId=0");
        }

        private void AddAppointment(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Appointment?appointmentId=0");
        }



        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            (BindingContext as MainViewModel)?.Refresh();
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel)?.Delete();
        }

        private void EditClicked(object sender, EventArgs e)
        {
            var selectedId = (BindingContext as MainViewModel)?.SelectedPatient?.Model?.Id ?? 0;
            Shell.Current.GoToAsync($"//Patient?patientId={selectedId}");
        }

        private void InlineEditClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel)?.Refresh();
        }
        private void SearchClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel)?.Search();
        }

        private void InlineAddClicked(object sender, EventArgs e)
        {
            var response = (BindingContext as MainViewModel)?.AddInlinePatient();
        }

        private void ExpandCardClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel)?.ExpandCard();
        }

        private void ExportClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel)?.Export();
        }

        private void ImportClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel)?.Import();
        }
        public void ForceRefresh()
        {
            (BindingContext as MainViewModel)?.Refresh();
        }

    }
}
