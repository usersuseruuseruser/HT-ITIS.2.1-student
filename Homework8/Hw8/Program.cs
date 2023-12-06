using System.Diagnostics.CodeAnalysis;
using Hw8.Calculator;

namespace Hw8;

[ExcludeFromCodeCoverage]
public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
    
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<ICalculator, CalculatorImpl>();
        builder.Services.AddMiniProfiler(options => options.RouteBasePath = "/profiler");

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Calculator}/{action=Index}");
        app.UseMiniProfiler();
        
        app.Run();
    }
}