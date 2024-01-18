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

namespace WPFDeskManager.ViewModels
{
    public class EditDeskVM : EntityWindowBase
    {
        private UpdateDeskDto _desk = new();
        private ObservableCollection<RoomBasicInfoDto> _rooms = new();
        private ObservableCollection<DeskStatusComboBox> _statuses = StaticData.DeskStatuses;
        private RoomBasicInfoDto _selectedRoom = new();
        private DeskStatusComboBox _selectedStatus = new();

        public UpdateDeskDto Desk
        {
            get { return _desk; }
            set { _desk = value; OnPropertyChanged(); }
        }
        public ObservableCollection<RoomBasicInfoDto> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; OnPropertyChanged(); }
        }
        public ObservableCollection<DeskStatusComboBox> Statuses
        {
            get { return _statuses; }
            set { _statuses = value; OnPropertyChanged(); }
        }
        public RoomBasicInfoDto SelectedRoom
        {
            get { return _selectedRoom; }
            set { _selectedRoom = value; ChangeSelectedRoom(); OnPropertyChanged(); }
        }

        public DeskStatusComboBox SelectedStatus
        {
            get { return _selectedStatus; }
            set { _selectedStatus = value; ChangeSelectedStatus(); OnPropertyChanged(); }
        }


        public override void SetWindowData()
        {
            EntityButtonContent = "OK";
            CancelButtonContent = "Anuluj";
        }

        public override async Task LoadDataAsync()
        {
            this.IsLoading = true;

            try
            {
                var result = await _restService.GetDeskByIdAsync(StaticData.CurrentEntityId);

                if(result != null)
                {
                    Desk = new UpdateDeskDto
                    {
                        Id = result.Id,
                        Name = result.Name,
                        MapXLocation = result.MapXLocation,
                        MapYLocation = result.MapYLocation,
                        Width = result.Width,
                        Height = result.Height,
                        RoomId = result.RoomId,
                        Status = result.Status,
                    };
                }

                Rooms = await _restService.GetRoomsBasicInfoAsync();
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
            EditDeskAsync(obj);
        }

        private async Task EditDeskAsync(object obj)
        {
            bool result = false;
            try
            {
                this.IsLoading = true;
                result = await _restService.UpdateDeskAsync(Desk);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                if (result)
                {
                    MessageBox.Show("Updated");
                    CloseButtonMethod(obj);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
        
        private void SetCheckboxData()
        {
            if(Desk is null)
            {
                return;
            }
            var status = StaticData.DeskStatuses.Where(s => s.DeskStatus == Desk.Status).FirstOrDefault();

            if (status != null)
            {
                SelectedStatus = new DeskStatusComboBox { Id = status.Id, Name = status.Name, DeskStatus = status.DeskStatus };
            }

            var room = Rooms.Where(r => r.Id == Desk.RoomId).FirstOrDefault();

            if (room != null)
            {
                SelectedRoom = new RoomBasicInfoDto { Id= room.Id, Name = room.Name };
            }
        }
        private void ChangeSelectedRoom()
        {
            if (Desk is null || SelectedRoom is null)
            {
                return;
            }

            Desk.RoomId = SelectedRoom.Id;
        }
        private void ChangeSelectedStatus()
        {
            if (Desk is null || SelectedStatus is null)
            {
                return;
            }

            Desk.Status = SelectedStatus.DeskStatus;
        }
    }
}
