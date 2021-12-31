using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Component;
using InternationalVillage_Customer.Store;
using InternationalVillage_Customer.Model;

namespace InternationalVillage_Customer.ViewModel
{
    class NotificationPageViewModel : BaseViewModel
    {
        public ICommand LoadNotification { get; set; }

        public NotificationPageViewModel()
        {
            LoadNotification = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                List<Notification> list = NotificationStore.Instance.GetListNotification(AccountStore.Instance.IdUser);

                foreach(Notification noti in list)
                {
                    NotificationUC notificationUC = new NotificationUC();
                    notificationUC.ContentOfNotification.Text = noti.Content;
                    notificationUC.TimeCreate.Text = noti.TimeCreate.ToString("MM/dd/yyyy HH:mm:ss");
                    p.Children.Add(notificationUC);
                }

                
            });
        }
    }
}
