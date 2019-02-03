using System;
using System.Windows.Input;
using ProjectMVVM.Service;
using ProjectMVVM.View;

namespace ProjectMVVM.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand OnClick { get; set; }

        public IPlatformLocationService LocationService { get; set; }

        public INavigationService NavigationService { get; set; }

        private string _welcomeText;

        public string WelcomeText
        {
            get => _welcomeText;
            set => SetValue(ref _welcomeText, value);
        }

        public MainPageViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            OnClick = new Xamarin.Forms.Command(NavigateToNextPage);
        }

        public void NavigateToNextPage()
        {
            LocationPageViewModel locationViewModel = new LocationPageViewModel(LocationService, NavigationService);
            locationViewModel.WelcomeText = "Welcome "+WelcomeText;

            NavigationService.Navigate(locationViewModel);
        }
    }
}
