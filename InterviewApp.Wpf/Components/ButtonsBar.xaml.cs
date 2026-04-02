using InterviewApp.Wpf;
using InterviewApp.Wpf.Services;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Wpf
{
    /// <summary>
    /// Interaction logic for ButtonsBar.xaml
    /// </summary>
    public partial class ButtonsBar : UserControl
    {
        private readonly INavigationService _navService;
        public ButtonsBar()
        {
            InitializeComponent();
            _navService = (Application.Current as App)?.ServiceProvider.GetService<INavigationService>();
        }

        private void GoToMainPage(object sender, RoutedEventArgs e)
        {
            _navService?.NavigateTo<MainPage>();
        }
        private void GoToCategoriesPage(object sender, RoutedEventArgs e)
        {
            _navService?.NavigateTo<Categories>();
        }

        private void GoToQuestionsPage(object sender, RoutedEventArgs e)
        {
            _navService?.NavigateTo<Questions>();
        }

        private void GoToInterviewsPage(object sender, RoutedEventArgs e)
        {
            _navService?.NavigateTo<Interviews>();
        }

    }
}
