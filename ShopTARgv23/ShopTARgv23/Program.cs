using ShopTARgv23.Data;
using Microsoft.EntityFrameworkCore;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.ApplicationServices.Services;
using Microsoft.Extensions.FileProviders;

using ShopTARgv23.ApplicationService.Services;


namespace ShopTARgv23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Добавление сервисов в контейнер зависимостей
            builder.Services.AddControllersWithViews();

            // Регистрация сервисов
            builder.Services.AddScoped<ISpaceshipServices, SpaceshipsServices>();
            builder.Services.AddScoped<IFileServices, FileServices>();
            builder.Services.AddScoped<IRealEstateServices, RealEstatesServices>();
            builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
            builder.Services.AddScoped<IKindergartenServices, KindergartenServices>();
            builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();
            builder.Services.AddScoped<IFreeGameServices, FreeGameServices>();
            builder.Services.AddScoped<ICocktailServices, CocktailServices>();

            // Настройка контекста базы данных
            builder.Services.AddDbContext<ShopTARgv23Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Настройка HTTP конвейера запросов
            if (!app.Environment.IsDevelopment())
            {
                // Использование обработчика исключений для продакшн-окружения
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // Включение HSTS для повышения безопасности
            }
            else
            {
                // Для режима разработки отображение подробных ошибок
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); // Редирект HTTP на HTTPS
            app.UseStaticFiles(); // Использование статических файлов

            // Настройка для дополнительных статических файлов
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
                RequestPath = "/multipleFileUpload"
            });

            app.UseRouting(); // Включение маршрутизации

            app.UseAuthorization(); // Включение авторизации

            // Настройка маршрутов
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Запуск приложения
            app.Run();
        }
    }
}
