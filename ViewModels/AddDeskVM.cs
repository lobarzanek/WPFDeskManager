using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class AddDeskVM : ViewModelBase
    {
        private readonly RestService _restService = new RestService();
        private AddDeskDto _addDeskDto;
        private ObservableCollection<RoomBasicInfoDto> _rooms;
        private ObservableCollection<DeskStatusDto> _statuses;
        private RoomBasicInfoDto _selectedRoom;
        private DeskStatusDto _selectedStatus;

        public ICommand AddDeskCommand { get; set; }

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
        public ObservableCollection<DeskStatusDto> Statuses
        {
            get { return _statuses; }
            set { _statuses = value; OnPropertyChanged(); }
        }
        public RoomBasicInfoDto SelectedRoom
        {
            get { return _selectedRoom; }
            set { _selectedRoom = value; ChangeSelectedRoom();}
        }

        public DeskStatusDto SelectedStatus
        {
            get { return _selectedStatus; }
            set { _selectedStatus = value; ChangeSelectedStatus(); }
        }

        public AddDeskVM()
        {
            AddDeskDto = new AddDeskDto();
            Statuses = _restService.GetDeskStatuses();
            Rooms = _restService.GetRoomsBasicInfo();
            AddDeskCommand = new RelayCommand(AddDesk, CanAddDesk);
        }

        private bool CanAddDesk(object arg)
        {
            return true;
        }

        private void AddDesk(object obj)
        {
            MessageBox.Show($"{AddDeskDto.Name}, {AddDeskDto.RoomId}, {AddDeskDto.StatusId}");
            //_restService.AddDesk();
        }
        private void ChangeSelectedRoom()
        {
            AddDeskDto.RoomName = SelectedRoom.Name;
            AddDeskDto.RoomId = SelectedRoom.Id;            
        }
        private void ChangeSelectedStatus()
        {
            AddDeskDto.StatusName = SelectedStatus.Name;
            AddDeskDto.StatusId = SelectedStatus.Id;
        }


    }
}
