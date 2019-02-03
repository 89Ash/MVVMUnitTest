using System;
using System.Collections.Generic;
using ProjectMVVM.View;
using ProjectMVVM.ViewModel;
using Xamarin.Forms;

namespace ProjectMVVM.View
{
    public class NavigationService : INavigationService
    {
        private Dictionary<Type, Type> mappingDictionary = new Dictionary<Type, Type>();


        public NavigationService()
        {
            RegisterMapping();
        }

        public void Navigate(BaseViewModel viewModel)
        {
            if (null != viewModel)
            {
                Application.Current.MainPage.Navigation.PushAsync(GetContentPage(viewModel));
            }
        }

        public void NavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void RegisterMapping()
        {
            mappingDictionary.Add(typeof(MainPageViewModel), typeof(ProjectMVVMPage));
            mappingDictionary.Add(typeof(LocationPageViewModel), typeof(LocationPage));
        }

        private ContentPage GetContentPage(object viewModel)
        {
            ContentPage contentPage = null;

            if ((mappingDictionary != null) && mappingDictionary.ContainsKey((viewModel.GetType())))
            {
                contentPage = (ContentPage)Activator.CreateInstance(mappingDictionary[viewModel.GetType()]);
                contentPage.BindingContext = viewModel;
            }

            return contentPage;
        }
    }
}
