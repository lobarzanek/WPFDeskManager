using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFDeskManager.Utilities;

namespace WPFDeskManager.ViewModels
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand ItemsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Items(object obj) => CurrentView = new ItemsVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ItemsCommand = new RelayCommand(Items);

            CurrentView = new HomeVM();
        }
    }
}
