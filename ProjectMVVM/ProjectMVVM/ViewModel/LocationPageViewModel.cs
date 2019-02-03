using System;
using System.Windows.Input;
using ProjectMVVM.Service;
using ProjectMVVM.View;

namespace ProjectMVVM.ViewModel
{
    public class LocationPageViewModel : BaseViewModel
    {
        public ICommand OnClick { get; set; }

        private string _locationText;

        public string LocationText 
        {
            get => _locationText;
            set => SetValue(ref _locationText, value);
        }

        private string _welcomeText;

        public string WelcomeText
        {
            get => _welcomeText;
            set => SetValue(ref _welcomeText, value);
        }

        private INavigationService _navigationService;

        public LocationPageViewModel()
        {

        }
            
        public LocationPageViewModel(IPlatformLocationService locationService, INavigationService navigationService)
        {
            Initialize();
            _navigationService = navigationService;

            LocationText = locationService.IsLocationServiceEnabled() == true ? "Location service is enabled on device." :
                                             "Location service is unable/turned off in the device.";
                               
        }

        private void Initialize()
        {
            OnClick = new Xamarin.Forms.Command(NavigateToPreviousPage);
        }

        public void NavigateToPreviousPage()
        {
            _navigationService.NavigateBack();
        }
    }
}
