using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ToastNotify.Model
{
    public class ToastNotifyItem
    {
        public string Text { get; set; }

        public ToastNotifyItemType Type { get; set; } = ToastNotifyItemType.Info;

        public string DivClass { get; set; }

        public Timer Timer { get; set; }
    }
}
