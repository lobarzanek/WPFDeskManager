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
    public class FloorsVM : ViewModelBase
    {
        private ObservableCollection<Floor> _floors;
        private string _nameTableHeader;
        private string _buildingNameTableHeader;

        public ObservableCollection<Floor> Floors
        {
            get { return _floors; }
            set { _floors = value; OnPropertyChanged(); }
        }
        public string NameTableHeader
        {
            get { return _nameTableHeader; }
            set { _nameTableHeader = value; OnPropertyChanged(); }
        }
        public string BuildingNameTableHeader
        {
            get { return _buildingNameTableHeader; }
            set { _buildingNameTableHeader = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            NameTableHeader = "Nazwa";
            BuildingNameTableHeader = "Budynek";
        }
        public override async Task LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                Floors = await _restService.GetFloorsAsync();
                PageTitle = $"Piętra: {Floors.Count}";
                AddButtonContent = "Dodaj piętro";
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
            AddFloor addWindow = new AddFloor();
            addWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addWindow.Show();
        }

        public override void ShowCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            ShowFloor showWindow = new ShowFloor();
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
            deleteEntityVM.EntityType = EntityType.Floor;

            DeleteEntity deleteEntityWindow = new DeleteEntity();
            deleteEntityWindow.DataContext = deleteEntityVM;
            deleteEntityWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            deleteEntityWindow.Show();
        }

        public override void EditCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            EditFloor editFloorWindow = new EditFloor();
            editFloorWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editFloorWindow.Show();
        }
    }
}
