using System;
using CoreLocation;
using ProjectMVVM.Service;

namespace ProjectMVVM.iOS.Service
{
    public class iOSLocationService : IPlatformLocationService
    {
        public bool IsLocationServiceEnabled()
        {
            bool status = false;

            if (CLLocationManager.LocationServicesEnabled)
                status = true;

            return status;
        }
    }
}
