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
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class EditRoomVM : EntityWindowBase
    {
        private UpdateRoomDto _room = new();
        private ObservableCollection<FloorBasicInfoDto> _floors = new();
        private FloorBasicInfoDto _selectedFloor = new();

        public UpdateRoomDto Room
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
            EntityButtonContent = "OK";
            CancelButtonContent = "Anuluj";
        }
        public override async Task LoadDataAsync()
        {

            try
            {
                this.IsLoading = true;

                var result = await _restService.GetRoomByIdAsync(StaticData.CurrentEntityId);

                if (result != null)
                {
                    Room = new UpdateRoomDto
                    {
                        Id = result.Id,
                        Name = result.Name,
                        FloorId = result.FloorId,
                    };
                }

                Floors = await _restService.GetFloorBasicInfoAsync();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                SetCheckboxData();
            }
        }

        public override void EntityButtonMethod(object obj)
        {
            EditRoomAsync(obj);
        }

        private async Task EditRoomAsync(object obj)
        {

            this.IsLoading = true;

            try
            {
                await _restService.UpdateRoomAsync(Room);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                CloseButtonMethod(obj);
                MessageBox.Show($"{Room.Id} | {Room.Name} | {Room.FloorId}");
            }
        }

        private void SetCheckboxData()
        {
            if (Room is null)
            {
                return;
            }

            var floor = Floors.Where(e => e.Id == Room.FloorId).FirstOrDefault();

            if (floor != null)
            {
                SelectedFloor = floor;
            }
        }
        private void ChangeSelectedFloor()
        {
            Room.FloorId = SelectedFloor.Id;
        }
    }
}
