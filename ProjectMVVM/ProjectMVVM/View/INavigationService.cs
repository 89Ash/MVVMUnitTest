using System;
using ProjectMVVM.ViewModel;

namespace ProjectMVVM.View
{
    public interface INavigationService
    {
        void Navigate(BaseViewModel viewModel);

        void NavigateBack();
    }
}
