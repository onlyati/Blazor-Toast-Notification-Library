# Toast Notify for Blazor

This is a javascript free toast notification function for Blazor server and wasm projects. Repo has 3 projects:
- ToastNotify: the library itself
- ToastNotifySampleServer: sample implementation for Blazor Server app
- ToastNotiySampleWASM: sample implementation for Blazor WASM app

## Usage
Download OnlyAti.Blazor.ToastNotify from nuget repository. In the `_import.razor` file, you must insert:
```csharp
@using ToastNotify;
@using ToastNotify.Controller
@using ToastNotify.Model

@inject ToastNotifyController ToastController 
```

If you use Blazor server app, then insert this line onto Startup.cs:
```
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

