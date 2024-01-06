using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Utilities;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class UsersVM : ViewModelBase
    {
        private ObservableCollection<User> _users = new();
        private string _firstNameTableHeader = "";
        private string _lastNameTableHeader = "";
        private string _loginTableHeader = "";
        private string _roleTableHeader = "";
        private string _teamTableHeader = "";

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged(); }
        }
        public string FirstNameTableHeader
        {
            get { return _firstNameTableHeader; }
            set { _firstNameTableHeader = value; OnPropertyChanged(); }
        }
        public string LastNameTableHeader
        {
            get { return _lastNameTableHeader; }
            set { _lastNameTableHeader = value; OnPropertyChanged(); }
        }
        public string LoginTableHeader
        {
            get { return _loginTableHeader; }
            set { _loginTableHeader = value; OnPropertyChanged(); }
        }
        public string RoleTableHeader
        {
            get { return _roleTableHeader; }
            set { _roleTableHeader = value; OnPropertyChanged(); }
        }
        public string TeamTableHeader
        {
            get { return _teamTableHeader; }
            set { _teamTableHeader = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            FirstNameTableHeader = "Imię";
            LastNameTableHeader = "Nazwisko";
            LoginTableHeader = "Login";
            RoleTableHeader = "Rola";
            TeamTableHeader = "Zespół";
            AddButtonContent = "Dodaj użytkownika";
        }
        public override async Task LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                Users = await _restService.GetUsersAsync();
                PageTitle = $"Użytkownicy: {Users.Count}";
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsLoading = false;
            }
        }
        public override void ShowAddWindow(object obj)
        {
            AddUser addWindow = new AddUser();
            addWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addWindow.Show();
        }

        public override void ShowCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            ShowUser showWindow = new ShowUser();
            showWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            showWindow.Show();
        }

        public override void DeleteCommandExecute(object parameter)
        {
            var values = (object[])parameter;
            var id = (int)values[0];
            var name = (string)values[1];

            DeleteEntityVM deleteEntityVM = new DeleteEntityVM();
            deleteEntityVM.EntityId = id;
            deleteEntityVM.EntityName = name;
            deleteEntityVM.EntityType = EntityType.User;

            DeleteEntity deleteEntityWindow = new DeleteEntity();
            deleteEntityWindow.DataContext = deleteEntityVM;
            deleteEntityWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            deleteEntityWindow.Show();
        }

        public override void EditCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            EditUser editWindow = new EditUser();
            editWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editWindow.Show();
        }
    }
}
