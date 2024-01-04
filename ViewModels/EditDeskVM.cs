﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;

namespace WPFDeskManager.ViewModels
{
    public class EditDeskVM : EntityWindowBase
    {
        private Desk _desk;
        private string _cancelButtonContent;
        private ObservableCollection<RoomBasicInfoDto> _rooms;
        private ObservableCollection<DeskStatusDto> _statuses;
        private RoomBasicInfoDto _selectedRoom;
        private DeskStatusDto _selectedStatus;

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
        public ObservableCollection<DeskStatusDto> Statuses
        {
            get { return _statuses; }
            set { _statuses = value; OnPropertyChanged(); }
        }
        public RoomBasicInfoDto SelectedRoom
        {
            get { return _selectedRoom; }
            set { _selectedRoom = value; ChangeSelectedRoom(); OnPropertyChanged(); }
        }

        public DeskStatusDto SelectedStatus
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
                await Task.Delay(2000);
                Statuses = _restService.GetDeskStatuses();
                Rooms = _restService.GetRoomsBasicInfo();
                Desk = _restService.GetDeskById(EntityId);
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
                await Task.Delay(2000);
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

        private void ChangeSelectedRoom()
        {
            Desk.RoomName = SelectedRoom.Name;
            Desk.RoomId = SelectedRoom.Id;
        }
        private void ChangeSelectedStatus()
        {
            Desk.StatusName = SelectedStatus.Name;
            Desk.StatusId = SelectedStatus.Id;
        }
        private void SetCheckboxData()
        {
            if(Desk is null)
            {
                return;
            }
            var status = Statuses.Where(s => s.Id == Desk.StatusId).FirstOrDefault();
            var room = Rooms.Where(r => r.Id == Desk.RoomId).FirstOrDefault();

            if (status != null)
            {
                SelectedStatus = new DeskStatusDto { Id = status.Id, Name = status.Name };
            }

            if (room != null)
            {
                SelectedRoom = new RoomBasicInfoDto { Id= room.Id, Name = room.Name };
            }
        }
    }
}