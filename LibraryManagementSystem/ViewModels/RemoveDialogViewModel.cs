using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewModels
{
    public class RemoveDialogViewModel : Screen
    {
        private bool _userInfoVisibility;
        private bool _bookInfoVisibility;
        private bool _rentInfoVisibility;

        public bool UserInfoVisibility
        {
            get { return _userInfoVisibility; }
            private set
            {
                _userInfoVisibility = value;
                NotifyOfPropertyChange(() => UserInfoVisibility);
            }
        }
        public bool BookInfoVisibility
        {
            get { return _bookInfoVisibility; }
            private set
            {
                _bookInfoVisibility = value;
                NotifyOfPropertyChange(() => BookInfoVisibility);
            }
        }
        public bool RentInfoVisibility
        {
            get { return _rentInfoVisibility; }
            private set
            {
                _rentInfoVisibility = value;
                NotifyOfPropertyChange(() => RentInfoVisibility);
            }
        }

        private int? _id;
        private string _login;
        private string _isbn;
        private string _bookName;
        private int? _book_id;

        public int? Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                NotifyOfPropertyChange(() => Login);
            }
        }
        public string ISBN
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                NotifyOfPropertyChange(() => ISBN);
            }
        }
        public string BookName
        {
            get { return _bookName; }
            set
            {
                _bookName = value;
                NotifyOfPropertyChange(() => BookName);
            }
        }
        public int? Book_Id
        {
            get { return _book_id; }
            set
            {
                _book_id = value;
                NotifyOfPropertyChange(() => Book_Id);
            }
        }

        public RemoveDialogViewModel(bool userInfo = false, bool bookInfo = false, bool rentInfo = false)
        {
            if (!userInfo && !bookInfo && !rentInfo)
            {
                throw new ArgumentException("You must pass one true boolean.");
            }
            if (userInfo && bookInfo || userInfo && rentInfo || bookInfo && rentInfo || userInfo && bookInfo && rentInfo)
            {
                throw new ArgumentException("You cannot pass more than 1 true boolean.");
            }

            if (rentInfo)
            {
                UserInfoVisibility = true;
                BookInfoVisibility = true;
                RentInfoVisibility = rentInfo;
            }
            else
            {
                UserInfoVisibility = userInfo;
                BookInfoVisibility = bookInfo;
            }
        }

        public void Close()
        {
            TryClose(false);
        }

        public void Select()
        {
            TryClose(true);
        }
    }
}
