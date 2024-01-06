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
        private string _homeButtonContent;
        private string _itemsButtonContent;
        private string _desksButtonContent;
        private string _desksStatusButtonContent;
        private string _floorsButtonContent;
        private string _buildingsButtonContent;
        private string _usersButtonContent;
        private string _brandsButtonContent;
        private string _teamsButtonContent;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public string HomeButtonContent
        {
            get { return _homeButtonContent; }
            set { _homeButtonContent = value; OnPropertyChanged(); }
        }
        public string ItemsButtonContent
        {
            get { return _itemsButtonContent; }
            set { _itemsButtonContent = value; OnPropertyChanged(); }
        }

        public string DesksButtonContent
        {
            get { return _desksButtonContent; }
            set { _desksButtonContent = value; OnPropertyChanged(); }
        }
        public string DeskStatusButtonContent
        {
            get { return _desksStatusButtonContent; }
            set { _desksStatusButtonContent = value; OnPropertyChanged(); }
        }
        public string FloorsButtonContent
        {
            get { return _floorsButtonContent; }
            set { _floorsButtonContent = value; OnPropertyChanged(); }
        }
        public string BuildingsButtonContent
        {
            get { return _buildingsButtonContent; }
            set { _buildingsButtonContent = value; OnPropertyChanged(); }
        }
        public string UsersButtonContent
        {
            get { return _usersButtonContent; }
            set { _usersButtonContent = value; OnPropertyChanged(); }
        }
        public string BrandsButtonContent
        {
            get { return _brandsButtonContent; }
            set { _brandsButtonContent = value; OnPropertyChanged(); }
        }
        public string TeamsButtonContent
        {
            get { return _teamsButtonContent; }
            set { _teamsButtonContent = value; OnPropertyChanged(); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand ItemsCommand { get; set; }
        public ICommand DesksCommand { get; set; }
        public ICommand DesksStatusCommand { get; set; }
        public ICommand FloorsCommand { get; set; }
        public ICommand BuildingsCommand { get; set; }
        public ICommand UsersCommand { get; set; }
        public ICommand BrandsCommand { get; set; }
        public ICommand TeamsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Items(object obj) => CurrentView = new ItemsVM();
        private void Desks(object obj) => CurrentView = new DesksVM();
        private void DeskStatus(object obj) => CurrentView = new DeskStatusVM();
        private void Floors(object obj) => CurrentView = new FloorsVM();
        private void Buildings(object obj) => CurrentView = new BuildingsVM();
        private void Users(object obj) => CurrentView = new UsersVM();
        private void Brands(object obj) => CurrentView = new BrandsVM();
        private void Teams(object obj) => CurrentView = new TeamsVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ItemsCommand = new RelayCommand(Items);
            DesksCommand = new RelayCommand(Desks);
            DesksStatusCommand = new RelayCommand(DeskStatus);
            FloorsCommand = new RelayCommand(Floors);
            BuildingsCommand = new RelayCommand(Buildings);
            UsersCommand = new RelayCommand(Users);
            BrandsCommand = new RelayCommand(Brands);
            TeamsCommand = new RelayCommand(Teams);

            CurrentView = new HomeVM();
        }

        public override void SetWindowData()
        {
            HomeButtonContent = "HOME";
            ItemsButtonContent = "WYPOSAŻENIE";
            DesksButtonContent = "BIURKA";
            DeskStatusButtonContent = "STATUSY BIUREK";
            FloorsButtonContent = "PIĘTRA";
            BuildingsButtonContent = "BUDYNKI";
            UsersButtonContent = "UŻYTKOWNICY";
            BrandsButtonContent = "MARKI";
            TeamsButtonContent = "ZESPOŁY";
        }
    }
}
