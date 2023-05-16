using Blazored.Toast;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Connections;
using OnBoarding.Services;
using Radzen;
using Serilog;
using SharedKernel.Interfaces;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((context, logger) => logger
           .ReadFrom.Configuration(context.Configuration));
    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddTransient<AppService>();
    builder.Services.AddScoped<IBaseDataAccess>(baseDataAccess => new BaseDataAccess(builder.Configuration.GetConnectionString("OnBoarding")));
    builder.Services.AddScoped<IOnBordingFormRepository, OnBordingFormRepository>();
    builder.Services.AddScoped<NotificationService>();
    builder.Services.AddScoped<DialogService>();
    builder.Services.AddBlazoredToast();

    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(options =>
                   {
                       options.Cookie.Name = ".OnBoarding.Cookies";
                   });

    var app = builder.Build();
    app.UseSerilogRequestLogging();
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }
    app.UseForwardedHeaders();
    app.UsePathBase("/onboarding/");

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapBlazorHub(options =>
    {
        options.Transports = HttpTransportType.LongPolling;
    });

    app.MapFallbackToPage("/_Host");

    app.Run();

    return 1;
}
catch (Exception exception)
{

    Log.Fatal(exception, "Host terminated unexpectedly");
    return 0;
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}