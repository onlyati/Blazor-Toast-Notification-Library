using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ToastNotify.Model;

namespace ToastNotify.Controller
{
    public class ToastNotifyController
    {
        public ObservableCollection<ToastNotifyItem> Lista;

        public event Action OnChange;

        public ToastNotifyController()
        {
            Lista = new();
            Lista.CollectionChanged += ItemAddedToList;
        }

        public void PushNotification(ToastNotifyItemType type, string text) => Lista.Add(new ToastNotifyItem() { Text = text, Type = type });

        public void RemoveNotification(object sender, ElapsedEventArgs e, ToastNotifyItem toastItem)
        {
            Console.WriteLine("Timer has run");
            toastItem.Timer.Enabled = false;
            if (Lista.IndexOf(toastItem) >= 0)
            {
                Lista.Remove(toastItem);
            }
        }

        void ItemAddedToList(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var actItem in e.NewItems)
                {
                    var item = actItem as ToastNotifyItem;

                    item.DivClass = $"onlyati-toastnotify-{item.Type.ToString().ToLower()}-item";

                    item.Timer = new(5000);
                    item.Timer.Elapsed += (sender, e) => RemoveNotification(sender, e, item);
                    item.Timer.Enabled = true;
                }
            }

            Console.WriteLine($"Event has run: {e.Action}");
            OnChange?.Invoke();
        }
    }
}
