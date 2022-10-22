using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using scheduleOff;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel((context, options) =>
{
    options.Configure(context.Configuration.GetSection("Kestrel"));
    options.AddServerHeader = false;
});

builder.Services.AddHostedService<Offhost>();

var app = builder.Build();


TaskScheduler.UnobservedTaskException += (_, e) =>
{
    app.Logger.LogError(e.Exception, "Unobserved Exception");
    e.SetObserved();
};

AppDomain.CurrentDomain.UnhandledException += (_, e) =>
{
    var ex = (Exception)e.ExceptionObject;

    if (e.IsTerminating)
    {
        app.Logger.LogCritical(ex, ex.Message);
    }
    else
    {
        app.Logger.LogError(ex, ex.Message);
    }
};
Console.Title = app.Environment.ApplicationName ?? string.Empty;
Console.OutputEncoding = Encoding.UTF8;

try
{
    app.Logger.LogDebug("Starting application...");
    app.Run();
}
catch (Exception e)
{
    app.Logger.LogCritical(e, "Unhandled exception");
}
finally
{
    app.Logger.LogInformation("Shut down complete");
}