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
    public class RoomsVM : ViewModelBase
    {
        private ObservableCollection<Room> _rooms;
        private string _nameTableHeader;
        private string _floorNameTableHeader;

        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; OnPropertyChanged(); }
        }
        public string NameTableHeader
        {
            get { return _nameTableHeader; }
            set { _nameTableHeader = value; OnPropertyChanged(); }
        }
        public string FloorNameTableHeader
        {
            get { return _floorNameTableHeader; }
            set { _floorNameTableHeader = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            NameTableHeader = "Nazwa";
            FloorNameTableHeader = "Piętro";
        }

        public override async Task LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                Rooms = await _restService.GetRoomsAsync();
                if (Rooms is not null)
                {
                    PageTitle = $"Pokoje: {Rooms.Count}";
                }
                else
                {
                    PageTitle = $"Błąd połączenia z serwerem";
                }
                AddButtonContent = "Dodaj pokój";
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
            AddRoom addWindow = new();
            addWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addWindow.Show();
        }

        public override void ShowCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            ShowRoom showWindow = new();
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
            deleteEntityVM.EntityType = EntityType.Room;

            DeleteEntity deleteEntityWindow = new DeleteEntity();
            deleteEntityWindow.DataContext = deleteEntityVM;
            deleteEntityWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            deleteEntityWindow.Show();
        }

        public override void EditCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            EditRoom editFloorWindow = new();
            editFloorWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editFloorWindow.Show();
        }
    }
}
