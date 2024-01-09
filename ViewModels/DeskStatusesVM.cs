using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class DeskStatusesVM : ViewModelBase
    {
        private ObservableCollection<DeskStatus> _deskStatuses;
        private string _nameTableHeader;

        public ObservableCollection<DeskStatus> DeskStatuses
        {
            get { return _deskStatuses; }
            set { _deskStatuses = value; OnPropertyChanged(); }
        }
        public string NameTableHeader
        {
            get { return _nameTableHeader; }
            set { _nameTableHeader = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            NameTableHeader = "Nazwa";
            AddButtonContent = "Dodaj status";
        }
        public override async Task LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                DeskStatuses = await _restService.GetDeskStatusesAsync();
                PageTitle = $"Statusy biurek: {DeskStatuses.Count}";

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
            AddDeskStatus addDeskStatusWindow = new AddDeskStatus();
            addDeskStatusWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addDeskStatusWindow.Show();
        }

        public override void ShowCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            ShowDeskStatus showWindow = new ShowDeskStatus();
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
            deleteEntityVM.EntityType = EntityType.DeskStatus;

            DeleteEntity deleteEntityWindow = new DeleteEntity();
            deleteEntityWindow.DataContext = deleteEntityVM;
            deleteEntityWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            deleteEntityWindow.Show();
        }

        public override void EditCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            EditDeskStatus editWindow = new EditDeskStatus();
            editWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editWindow.Show();
        }
    }
}
