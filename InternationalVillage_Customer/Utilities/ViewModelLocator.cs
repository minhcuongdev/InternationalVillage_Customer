using InternationalVillage_Customer.Services;
using InternationalVillage_Customer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace InternationalVillage_Customer.Utilities
{
    class ViewModelLocator
    {
        private UnityContainer container;

        public ViewModelLocator()
        {
            container = new UnityContainer();
            container.RegisterType<IChatService, ChatService>();
            container.RegisterType<IDialogService, DialogService>();
        }

        public MenuViewModel MenuVM
        {
            get { return container.Resolve<MenuViewModel>(); }
        }

        public ChatViewModel ChatVM
        {
            get { return container.Resolve<ChatViewModel>(); }
        }

       
    }
}
