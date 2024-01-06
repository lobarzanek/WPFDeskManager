using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;

namespace WPFDeskManager.ViewModels
{
    public class EditDeskVM : EntityWindowBase
    {
        private Desk _desk = new Desk();
        private string _cancelButtonContent;
        private ObservableCollection<RoomBasicInfoDto> _rooms;
        private ObservableCollection<DeskStatus> _statuses;
        private RoomBasicInfoDto _selectedRoom = new RoomBasicInfoDto();
        private DeskStatus _selectedStatus = new DeskStatus();

        public Desk Desk
        {
            get { return _desk; }
            set { _desk = value; OnPropertyChanged(); }
        }
        public string CancelButtonContent
        {
            get { return _cancelButtonContent; }
            set { _cancelButtonContent = value; OnPropertyChanged(); }
        }
        public ObservableCollection<RoomBasicInfoDto> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; OnPropertyChanged(); }
        }
        public ObservableCollection<DeskStatus> Statuses
        {
            get { return _statuses; }
            set { _statuses = value; OnPropertyChanged(); }
        }
        public RoomBasicInfoDto SelectedRoom
        {
            get { return _selectedRoom; }
            set { _selectedRoom = value; ChangeSelectedRoom(); OnPropertyChanged(); }
        }

        public DeskStatus SelectedStatus
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
                Desk = await _restService.GetDeskByIdAsync(StaticData.CurrentEntityId);

                Statuses = await _restService.GetDeskStatusesAsync();
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
            try
            {
                this.IsLoading = true;
                await _restService.UpdateDeskAsync(Desk);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                CloseButtonMethod(obj);
                MessageBox.Show($"{Desk.Name}, {Desk.RoomId}, {Desk.StatusId}");
            }
        }
        
        private void SetCheckboxData()
        {
            if(Desk is null)
            {
                return;
            }
            var status = Statuses.Where(s => s.Id == Desk.StatusId).FirstOrDefault();

            if (status != null)
            {
                SelectedStatus = new DeskStatus { Id = status.Id, Name = status.Name };
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

            Desk.RoomName = SelectedRoom.Name;
            Desk.RoomId = SelectedRoom.Id;
        }
        private void ChangeSelectedStatus()
        {
            if (Desk is null || SelectedStatus is null)
            {
                return;
            }

            Desk.StatusName = SelectedStatus.Name;
            Desk.StatusId = SelectedStatus.Id;
        }
    }
}
