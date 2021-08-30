using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotify.Model;
using ToastNotify.Controller;

namespace ToastNotify.Service
{
    public static class ServiceCollectionExtension
    {
        public static void AddToastNotify(this IServiceCollection service)
        {
            service.AddScoped<ToastNotifyController>();
        }
    }
}
