using ProjectMVVM.Service;
using ProjectMVVM.View;
using ProjectMVVM.ViewModel;
using Xamarin.Forms;

namespace ProjectMVVM
{
    public partial class App : Application
    {
        private IPlatformLocationService _locationService;

        public IPlatformLocationService LocationService
        {
            get => _locationService; 
            set
            {
                _locationService = value;
                mainPageViewModel.LocationService = _locationService;
            }
        }

        private MainPageViewModel mainPageViewModel;

        public App()
        {
            InitializeComponent();
            mainPageViewModel = new MainPageViewModel()
            {
                NavigationService = new NavigationService(),
                LocationService = LocationService

            };

            MainPage = new NavigationPage(new ProjectMVVMPage()
            {
                BindingContext = mainPageViewModel
            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
