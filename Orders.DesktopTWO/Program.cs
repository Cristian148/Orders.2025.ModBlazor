using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.DesktopTWO.Controllers;
using Orders.DesktopTWO.Data;
using Orders.DesktopTWO.Repositories.Implementations;
using Orders.DesktopTWO.Repositories.Interfaces;
using Orders.DesktopTWO.UnitsOfWork.Implementations;
using Orders.DesktopTWO.UnitsOfWork.Interfaces;
using Orders.Shared.Entites;

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

          
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
            services.AddScoped<ICategoriesUnitOfWork,CategoriesUnitOfWork>();


           

            services.AddTransient<Form1>(); 
            services.AddTransient<Form2>();
            services.AddTransient<Form3>();
            services.AddTransient<FrmCategories>();
            //services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            //builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
            //builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
            //builder.Services.AddScoped<IStatesRepository, StatesRepository>();

            //builder.Services.AddScoped<ICategoriesUnitOfWork, CategoriesUnitOfWork>();
            //builder.Services.AddScoped<ICitiesUnitOfWork, CitiesUnitOfWork>();
            //builder.Services.AddScoped<ICountriesUnitOfWork, CountriesUnitOfWork>();
            //builder.Services.AddScoped<IStatesUnitOfWork, StatesUnitOfWork>();


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