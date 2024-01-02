using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;

namespace WPFDeskManager.ViewModels
{
    public class DesksVM : ViewModelBase
    {
        private readonly RestService _restService = new RestService();
        private ObservableCollection<Desk> _desks;

        public ICommand ShowAddWindowCommand { get; set; }

        public ObservableCollection<Desk> Desks 
        { 
            get { return _desks; } 
            set { _desks = value; OnPropertyChanged(); } 
        }

        public DesksVM()
        {
            Initialize();
        }

        private void Initialize()
        {
            LoadDataAsync();
            ShowAddWindowCommand = new RelayCommand(ShowAddWindow);
        }

        public async Task LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                await Task.Delay(2000);
                Desks = (ObservableCollection<Desk>)_restService.GetDesks();
                PageTitle = $"Desks: {Desks.Count}";
                AddButtonContent = "Dodaj biurko";

            }
            catch (Exception ex)
            {

            }
            finally 
            { 
                IsLoading = false; 
            }
        }
        private void ShowAddWindow(object obj)
        {
            var mainWindow = obj as Window;

            //AddUser addUserWin = new AddUser();
            //addUserWin.Owner = mainWindow;
            //addUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //addUserWin.Show();


        }




    }
}
