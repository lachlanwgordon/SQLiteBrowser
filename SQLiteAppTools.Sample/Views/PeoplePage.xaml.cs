using System;
using SQLiteAppTools.Sample.ViewModels;
using Xamarin.Forms;


namespace SQLiteAppTools.Sample.Views
{
    public partial class PeoplePage : ContentPage
    {
        public PeoplePageViewModel ViewModel { get; set; } = new PeoplePageViewModel();
        public PeoplePage()
        {
            BindingContext = ViewModel;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.InitializeAsync();
        }
    }
}