using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;
using System.Windows;

namespace WPFDeskManager.ViewModels
{
    public class AddRoomVM : EntityWindowBase
    {
        private AddRoomDto _room = new();
        private ObservableCollection<FloorBasicInfoDto> _floors = new ObservableCollection<FloorBasicInfoDto>();
        private FloorBasicInfoDto _selectedFloor = new();

        public AddRoomDto Room
        {
            get { return _room; }
            set { _room = value; OnPropertyChanged(); }
        }
        public ObservableCollection<FloorBasicInfoDto> Floors
        {
            get { return _floors; }
            set { _floors = value; OnPropertyChanged(); }
        }
        public FloorBasicInfoDto SelectedFloor
        {
            get { return _selectedFloor; }
            set { _selectedFloor = value; ChangeSelectedFloor(); OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            Room = new AddRoomDto();
            EntityButtonContent = "Dodaj";
        }
        public override async Task LoadDataAsync()
        {
            this.IsLoading = true;

            try
            {
                Floors = await _restService.GetFloorBasicInfoAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
            }
        }
        public override void EntityButtonMethod(object obj)
        {
            AddRoomAsync();
        }
        private async Task AddRoomAsync()
        {
            bool result = false;

            try
            {
                this.IsLoading = true;
                result = await _restService.AddRoomAsync(Room);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                if (result)
                {
                    MessageBox.Show("Added");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
        private void ChangeSelectedFloor()
        {
            Room.FloorId = SelectedFloor.Id;
        }
    }
}
