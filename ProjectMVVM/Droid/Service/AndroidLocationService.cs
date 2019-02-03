using System;
using Android.Content;
using Android.Locations;
using ProjectMVVM.Service;

namespace ProjectMVVM.Droid.Service
{
    public class AndroidLocationService : IPlatformLocationService
    {
        LocationManager locationManager = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);


        public bool IsLocationServiceEnabled()
        {
            bool isLocationTurnedOn = false;

            if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == true)
                isLocationTurnedOn = true;

            return isLocationTurnedOn;
        }
    }
}
