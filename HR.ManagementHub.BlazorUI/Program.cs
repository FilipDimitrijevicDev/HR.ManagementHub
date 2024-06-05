using HR.ManagementHub.BlazorUI.Common.Interfaces;
using HR.ManagementHub.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

namespace HR.ManagementHub.BlazorUI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7276"));

        builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
        builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
        builder.Services.AddScoped<ILeaveDistributionService, LeaveDistributionService>();

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        await builder.Build().RunAsync();
    }
}
