using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewModels
{
    public class BaseViewModel : Screen
    {
        protected MainViewModel MainView;

        protected void SwitchView(BaseViewModel view)
        {
            MainView.CurrentView = view;
            MainView.ActivateItem(MainView.CurrentView);
        }
    }
}
