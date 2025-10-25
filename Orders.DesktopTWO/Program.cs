using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.DesktopTWO.Data;

namespace Orders.DesktopTWO
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddDbContext<DataContext>(options =>
            {
                //options.UseSqlServer("Server=(local)\\SQLEXPRESS,49500;Database=Orders2025ModBlazor;Trusted_Connection=True;TrustServerCertificate=True;");
                options.UseSqlServer("appsettings.json");
            });

            services.AddTransient<Form1>(); 
            services.AddTransient<Form2>();
            var serviceProvider = services.BuildServiceProvider();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = serviceProvider.GetRequiredService<Form1>();
            Application.Run(mainForm);

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
    }
}