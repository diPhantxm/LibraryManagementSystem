using Caliburn.Micro;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LibraryManagementSystem.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private bool Processing = false;

        public string Login { get; set; }
        public string Password { get; set; }

        private Brush _topBorderBrush = Brushes.Black;
        private Brush _bottomBorderBrush = Brushes.Black;

        public Brush TopBorderBrush
        {
            get { return _topBorderBrush; }
            set
            {
                _topBorderBrush = value;
                NotifyOfPropertyChange(() => TopBorderBrush);
            }
        }
        public Brush BottomBorderBrush
        {
            get { return _bottomBorderBrush; }
            set
            {
                _bottomBorderBrush = value;
                NotifyOfPropertyChange(() => BottomBorderBrush);
            }
        }



        public LoginViewModel(MainViewModel mainView)
        {
            MainView = mainView;
        }

        public async Task SignIn()
        {
            await Task.Run(async () =>
            {
                if (Processing) return;
                else Processing = true;

                #region Input Check

                if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
                {
                    TopBorderBrush = Brushes.Red;
                    BottomBorderBrush = Brushes.Red;

                    Processing = false;

                    return;
                }

                #endregion

                try
                {
                    await Managers.UserManager.AuthenticateAsync(Login, Password);

                    Processing = false;

                    if (Managers.UserManager.CurrentUser != null)
                    {
                        SwitchView(new BooksListViewModel(MainView));
                    }
                    else
                    {
                        TopBorderBrush = Brushes.Red;
                        BottomBorderBrush = Brushes.Red;

                        return;
                    }
                }
                catch (Exception)
                {
                    Processing = false;

                    return;
                }
            });
        }

        public void SignUp()
        {
            SwitchView(new RegisterViewModel(MainView));
        }
    }
}
