using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Component;

namespace InternationalVillage_Customer.ViewModel
{
    class NotificationPageViewModel : BaseViewModel
    {
        public ICommand LoadNotification { get; set; }

        public NotificationPageViewModel()
        {
            LoadNotification = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                for(int i=0;i<20;i++)
                {
                    NotificationUC notificationUC = new NotificationUC();
                    notificationUC.ContentOfNotification.Text = i.ToString();
                    p.Children.Add(notificationUC);
                }
            });
        }
    }
}
