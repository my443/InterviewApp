using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace InterviewApp.Wpf.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        public event Action<Page> OnNavigated;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<T>() where T : Page
        {
            var page = _serviceProvider.GetService(typeof(T)) as Page;
            if (page != null)
            {
                OnNavigated?.Invoke(page);
            }
        }
    }
}
