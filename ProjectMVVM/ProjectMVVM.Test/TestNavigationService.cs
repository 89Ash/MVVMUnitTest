using System;
using ProjectMVVM.View;
using ProjectMVVM.ViewModel;

namespace ProjectMVVM.Test
{
    public class TestNavigationService : INavigationService
    {

        public object ViewModel { get; set; }

        public void Navigate(BaseViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void NavigateBack()
        {
            ViewModel = typeof(MainPageViewModel);
        }
    }
}
