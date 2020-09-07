using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace LibraryManagementSystem.ViewModels
{
    public class IdToUpdateDialogViewModel : Screen
    {
        private int _id;
        private int _book_id;
        private bool _bookIdVisibility;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
        public int Book_Id
        {
            get { return _book_id; }
            set
            {
                _book_id = value;
                NotifyOfPropertyChange(() => Book_Id);
            }
        }
        public bool BookIdVisibility
        {
            get { return _bookIdVisibility; }
            set
            {
                _bookIdVisibility = value;
                NotifyOfPropertyChange(() => BookIdVisibility);
            }
        }

        public IdToUpdateDialogViewModel(bool bookInfo = false)
        {
            BookIdVisibility = bookInfo;
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
