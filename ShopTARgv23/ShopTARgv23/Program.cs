using ShopTARgv23.Data;
using Microsoft.EntityFrameworkCore;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.ApplicationServices.Services;
using Microsoft.Extensions.FileProviders;


using ShopTARgv23.ApplicationService.Services;
using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Identity;


namespace ShopTARgv23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� �������� � ��������� ������������
            builder.Services.AddControllersWithViews();

            // ����������� ��������
            builder.Services.AddScoped<ISpaceshipServices, SpaceshipsServices>();
            builder.Services.AddScoped<IFileServices, FileServices>();
            builder.Services.AddScoped<IRealEstateServices, RealEstatesServices>();
            builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
            builder.Services.AddScoped<IKindergartenServices, KindergartenServices>();
            builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();
            builder.Services.AddScoped<IFreeGameServices, FreeGameServices>();
            builder.Services.AddScoped<ICocktailServices, CocktailServices>();
            builder.Services.AddScoped<IEmailsServices, EmailsServices>();

            // ��������� ��������� ���� ������
            builder.Services.AddDbContext<ShopTARgv23Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 3;

                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<ShopTARgv23Context>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
            .AddDefaultUI();


            var app = builder.Build();

            // ��������� HTTP ��������� ��������
            if (!app.Environment.IsDevelopment())
            {
                // ������������� ����������� ���������� ��� ��������-���������
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // ��������� HSTS ��� ��������� ������������
            }
            else
            {
                // ��� ������ ���������� ����������� ��������� ������
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); // �������� HTTP �� HTTPS
            app.UseStaticFiles(); // ������������� ����������� ������

            // ��������� ��� �������������� ����������� ������
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
                RequestPath = "/multipleFileUpload"
            });

            app.UseRouting(); // ��������� �������������

            app.UseAuthorization(); // ��������� �����������

            // ��������� ���������
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // ������ ����������
            app.Run();
        }
    }
}
