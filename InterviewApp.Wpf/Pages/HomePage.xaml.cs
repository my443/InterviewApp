using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private readonly IServiceProvider _serviceProvider;
        public HomePage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        public void GoToCategoriesPage(object sender, RoutedEventArgs e)
        {
            // 1. Get the navigation service that is hosting this page
            var nav = NavigationService.GetNavigationService(this);

            if (nav != null)
            {
                // 2. Resolve the page from DI (Preferred)
                // Note: You'll need to inject IServiceProvider into your HomePage constructor
                var categoriesPage = _serviceProvider.GetRequiredService<Categories>();

                // 3. Perform the navigation
                nav.Navigate(categoriesPage);
            }
        }
    }
}
