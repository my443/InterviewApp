using InterviewApp.Data;
using InterviewApp.Services;
using InterviewApp.Wpf.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace InterviewApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
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

            // Register the Navigation Service
            services.AddSingleton<INavigationService, NavigationService>();

            // Register your Window and Pages
            services.AddSingleton<MainWindow>();
            services.AddTransient<ButtonsBar>();
            services.AddTransient<HomePage>();
            services.AddTransient<Categories>();
            services.AddTransient<Questions>();
            services.AddTransient<Interviews>();
            services.AddTransient<Settings>();

            // 3. Register your Windows (This is key for WPF DI!)
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Instead of letting App.xaml open the window, we resolve it from DI
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
