using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using InterviewApp.Data;
using InterviewApp.Services;

namespace InterviewApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // 1. Register your DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=interview.db"));

            // 2. Register your Services
            services.AddScoped<CategoryService>();
            services.AddScoped<QuestionService>();
            services.AddScoped<InterviewTemplateService>();

            // Register Pages
            services.AddTransient<Categories>();
            services.AddTransient<MainPage>();

            // 3. Register your Windows (This is key for WPF DI!)
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Instead of letting App.xaml open the window, we resolve it from DI
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
