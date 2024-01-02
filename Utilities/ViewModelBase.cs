using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFDeskManager.Utilities
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool _isLoading;
        private string _addButtonContent;
        private string _pageTitle;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(); }
        }
        public string AddButtonContent
        {
            get { return _addButtonContent; }
            set { _addButtonContent = value; OnPropertyChanged(); }
        }
        public string PageTitle
        {
            get { return _pageTitle; }
            set { _pageTitle = value; OnPropertyChanged(); }
        }

        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        

    }
}
