# Toast Notify for Blazor

This is a javascript free toast notification function for Blazor server and wasm projects. Repo has 3 projects:
- ToastNotify: the library itself
- ToastNotifySampleServer: sample implementation for Blazor Server app
- ToastNotiySampleWASM: sample implementation for Blazor WASM app

## Installation
Download OnlyAti.Blazor.ToastNotify from nuget repository. In the `_import.razor` file, you must insert:
```csharp
@using ToastNotify;
@using ToastNotify.Controller
@using ToastNotify.Model

@inject ToastNotifyController ToastController 
```

If you use Blazor server app, then insert this line onto Startup.cs:
```csharp
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddToastNotify(); /* <--- INSERT THIS LINE */
        }
```

If you use Blazor WASM app, then insert this line onto program.cs:
```csharp
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddToastNotify(); /* <--- INSERT THIS LINE */

            await builder.Build().RunAsync();
        }

```

In case of Blazor server app you must paste onto `Pages/_Host.cshtml`. In case of Blazor WASM app, you must paste onto `wwwroot/index.html`. Both case it must be between header tags.
```html
<link href="_content/ToastNotify/ToastNotify.css" rel="stylesheet" />
```

At the end, you must put the controller into your MainLayout file:
```
<ToastNotifyView ToastController="@ToastController" />
```

You can check samples for both situation in this repo.

## Usage
It is simple to use due to DI. You can just call function to push message:
```csharp
ToastController.PushNotification(ToastNotifyItemType.Info, "Info notificatioin");
ToastController.PushNotification(ToastNotifyItemType.Warning, "Warning notificatioin");
ToastController.PushNotification(ToastNotifyItemType.Error, "Error notificatioin was sent due to something error: there is nothing to see here...");
```

Notification pops up in the upper right corner and disappear after 5 seconds.
More configuration options is planned in the future.