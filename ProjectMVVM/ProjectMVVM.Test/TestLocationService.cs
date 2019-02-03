using System;
using ProjectMVVM.Service;

namespace ProjectMVVM.Test
{
    public class TestLocationService : IPlatformLocationService
    {
        public bool LocationEnabled { get; set; }

        public bool IsLocationServiceEnabled()
        {
            return LocationEnabled;
        }
    }
}
