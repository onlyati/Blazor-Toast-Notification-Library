using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotify.Controller;

namespace ToastNotify
{
    public  partial class ToastNotifyView : ComponentBase
    {
        [Parameter]
        public ToastNotifyController ToastController { get; set; }

        protected override void OnInitialized()
        {
            ToastController.OnChange += OnChangeCall;
        }

        public void Dispose()
        {
            ToastController.OnChange -= OnChangeCall;
        }

        public void OnChangeCall()
        {
            InvokeAsync(() => StateHasChanged());
        }
    }
}
