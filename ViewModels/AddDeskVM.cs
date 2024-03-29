﻿using System;
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
        private RoomBasicInfoDto _selectedRoom;

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
        public RoomBasicInfoDto SelectedRoom
        {
            get { return _selectedRoom; }
            set { _selectedRoom = value; ChangeSelectedRoom();}
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
            bool result = false;

            try
            {
                this.IsLoading = true;
                result = await _restService.AddDeskAsync(AddDeskDto);
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

        private void ChangeSelectedRoom()
        {
            AddDeskDto.RoomId = SelectedRoom.Id;            
        }

    }
}
