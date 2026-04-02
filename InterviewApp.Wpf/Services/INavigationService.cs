using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace InterviewApp.Wpf.Services
{
    public interface INavigationService
    {
        void NavigateTo<T>() where T : Page;
        event Action<Page> OnNavigated;
    }
}
