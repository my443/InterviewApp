using InterviewApp.Wpf.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterviewApp.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly INavigationService _navService;

        public MainWindow(IServiceProvider serviceProvider, INavigationService navService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            // Navigate to a default page on startup
            GoToMainPage();

            _navService = navService;

            // THIS IS THE MISSING LINK:
            // When the service says "Navigate", the Window tells the Frame to show the page.
            _navService.OnNavigated += (page) =>
            {
                MainFrame.Navigate(page);
            };

            // Optional: Navigate to home on startup
            _navService.NavigateTo<MainPage>();
        }

        public void GoToCategoriesPage(object sender, RoutedEventArgs e)
        {
            // RESOLVE the page from DI instead of 'new Categories()'
            var categoriesPage = _serviceProvider.GetRequiredService<Categories>();

            // NAVIGATE the frame instead of setting 'this.Content'
            MainFrame.Navigate(categoriesPage);
        }

        private void GoToMainPage()
        {
            var homePage = _serviceProvider.GetRequiredService<MainPage>();
            MainFrame.Navigate(homePage);
        }


    }
}