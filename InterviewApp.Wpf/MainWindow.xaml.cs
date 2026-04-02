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

        private readonly INavigationService _navService;

        public MainWindow(INavigationService navService)
        {
            InitializeComponent();




            _navService = navService;

            // THIS IS THE MISSING LINK:
            // When the service says "Navigate", the Window tells the Frame to show the page.
            _navService.OnNavigated += (page) =>
            {
                MainFrame.Navigate(page);
            };

            // Optional: Navigate to home on startup
            _navService.NavigateTo<HomePage>();
        }




    }
}