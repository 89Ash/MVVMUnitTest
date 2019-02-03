using NUnit.Framework;
using System;
using ProjectMVVM.ViewModel;
using ProjectMVVM.View;
using ProjectMVVM.Service;

namespace ProjectMVVM.Test
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void navigate_to_second_page_when_next_button_is_clicked()
        {
            TestNavigationService testNavigationService = new TestNavigationService();
            TestLocationService testLocationService = new TestLocationService();

            var mainPageViewModel = new MainPageViewModel();
            mainPageViewModel.LocationService = testLocationService;
            mainPageViewModel.NavigationService = testNavigationService;

            if(mainPageViewModel.OnClick.CanExecute(null))
            {
                mainPageViewModel.OnClick.Execute(null);
            }

            Assert.AreEqual(typeof(LocationPageViewModel),  testNavigationService.ViewModel.GetType());
        }

        [Test()]
        public void display_appropriate_location_text_on_landing_to_second_page()
        {
            TestNavigationService testNavigationService = new TestNavigationService();
            TestLocationService testLocationService = new TestLocationService();

            testLocationService.LocationEnabled = true;
            var locationPageViewModel = new LocationPageViewModel(testLocationService, testNavigationService);

            if (locationPageViewModel.OnClick.CanExecute(null))
            {
                locationPageViewModel.OnClick.Execute(null);
            }

            Assert.AreEqual("Location service is enabled on device.", locationPageViewModel.LocationText);

            testLocationService.LocationEnabled = false;
            locationPageViewModel = new LocationPageViewModel(testLocationService, testNavigationService);

            if (locationPageViewModel.OnClick.CanExecute(null))
            {
                locationPageViewModel.OnClick.Execute(null);
            }

            Assert.AreEqual("Location service is unable/turned off in the device.", locationPageViewModel.LocationText);
        }

        [Test()]
        public void display_appropriate_display_message_on_landing_to_second_page()
        {
            TestNavigationService testNavigationService = new TestNavigationService();
            TestLocationService testLocationService = new TestLocationService();

            var mainPageViewModel = new MainPageViewModel();
            mainPageViewModel.LocationService = testLocationService;
            mainPageViewModel.NavigationService = testNavigationService;
            mainPageViewModel.WelcomeText = "Ashray";

            if (mainPageViewModel.OnClick.CanExecute(null))
            {
                mainPageViewModel.OnClick.Execute(null);
            }

            Assert.AreEqual("Welcome Ashray", ((LocationPageViewModel)testNavigationService.ViewModel).WelcomeText);
        }

        [Test()]
        public void navigate_to_previous_page_when_back_button_is_clicked()
        {
            TestNavigationService testNavigationService = new TestNavigationService();
            TestLocationService testLocationService = new TestLocationService();

            var locationPageViewModel = new LocationPageViewModel(testLocationService, testNavigationService);

            if (locationPageViewModel.OnClick.CanExecute(null))
            {
                locationPageViewModel.OnClick.Execute(null);
            }

            Assert.AreEqual(typeof(MainPageViewModel), testNavigationService.ViewModel);
        }


    }
}
