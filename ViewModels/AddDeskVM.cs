using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class AddDeskVM : EntityWindowBase
    {
        private AddDeskDto _addDeskDto;
        private ObservableCollection<RoomBasicInfoDto> _rooms;
        private ObservableCollection<DeskStatus> _statuses;
        private RoomBasicInfoDto _selectedRoom;
        private DeskStatus _selectedStatus;

        public AddDeskDto AddDeskDto
        {
            get { return _addDeskDto; }
            set { _addDeskDto = value; OnPropertyChanged(); }
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
            set { _selectedRoom = value; ChangeSelectedRoom();}
        }

        public DeskStatus SelectedStatus
        {
            get { return _selectedStatus; }
            set { _selectedStatus = value; ChangeSelectedStatus(); }
        }

        public override void SetWindowData()
        {
            AddDeskDto = new AddDeskDto();
            EntityButtonContent = "Dodaj biurko";
        }

        public override async Task LoadDataAsync()
        {
            this.IsLoading = true;

            try
            {
                Statuses = await _restService.GetDeskStatusesAsync();
                Rooms = await _restService.GetRoomsBasicInfoAsync();
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
            AddDeskAsync();
        }

        private async Task AddDeskAsync()
        {
            try
            {
                this.IsLoading = true;
                await Task.Delay(2000);                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                MessageBox.Show($"{AddDeskDto.Name}, {AddDeskDto.RoomId}, {AddDeskDto.StatusId}");
            }
        }

        private void ChangeSelectedRoom()
        {
            AddDeskDto.RoomId = SelectedRoom.Id;            
        }
        private void ChangeSelectedStatus()
        {
            AddDeskDto.StatusId = SelectedStatus.Id;
        }


    }
}
