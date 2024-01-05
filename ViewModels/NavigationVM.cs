using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFDeskManager.Utilities.Base;

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
        public ICommand DesksCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Items(object obj) => CurrentView = new ItemsVM();
        private void Desks(object obj) => CurrentView = new DesksVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ItemsCommand = new RelayCommand(Items);
            DesksCommand = new RelayCommand(Desks);

            CurrentView = new HomeVM();
        }
    }
}
