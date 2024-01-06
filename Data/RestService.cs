﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;

namespace WPFDeskManager.Data
{
    public class RestService
    {
        public RestService()
        {

        }

        public ICollection<Item> GetItemsAsync()
        {

            var _items = new ObservableCollection<Item>() {
                new Item()
                {
                    Id = 1,
                    Name = "Mouse #1",
                    AddDate = new DateTime(2023, 12, 21, 5, 10, 20),
                    SerialNumber = "abc123def456",
                    Status = ItemStatus.Free,
                    Type = ItemType.Mouse,
                    OwnerId = 1,
                    OwnerName = "User #1",
                    BrandId = 1,
                    BrandName = "Brand #1",
                    DeskId = null,
                    DeskName = null,
                },
                new Item()
                {
                    Id = 2,
                    Name = "Mouse #2",
                    AddDate = new DateTime(2023, 12, 22, 6, 30, 28),
                    SerialNumber = "m8c32nac09c",
                    Status = ItemStatus.Used,
                    Type = ItemType.Mouse,
                    OwnerId = 2,
                    OwnerName = "User #2",
                    BrandId = 2,
                    BrandName = "Brand #2",
                    DeskId = 1,
                    DeskName = "Desk #1",
                },
                new Item()
                {
                    Id = 3,
                    Name = "Keyboard #3",
                    AddDate = new DateTime(2023, 12, 22, 8, 30, 28),
                    SerialNumber = "nc8cqfhd9q",
                    Status = ItemStatus.Used,
                    Type = ItemType.Keyboard,
                    OwnerId = 2,
                    OwnerName = "User #2",
                    BrandId = 2,
                    BrandName = "Brand #2",
                    DeskId = 1,
                    DeskName = "Desk #1",
                },new Item()
                {
                    Id = 4,
                    Name = "Mouse #4",
                    AddDate = new DateTime(2023, 12, 21, 5, 10, 20),
                    SerialNumber = "abc123def456",
                    Status = ItemStatus.Free,
                    Type = ItemType.Mouse,
                    OwnerId = 1,
                    OwnerName = "User #1",
                    BrandId = 1,
                    BrandName = "Brand #1",
                    DeskId = null,
                    DeskName = null,
                },
                new Item()
                {
                    Id = 5,
                    Name = "Mouse #5",
                    AddDate = new DateTime(2023, 12, 22, 6, 30, 28),
                    SerialNumber = "m8c32nac09c",
                    Status = ItemStatus.Used,
                    Type = ItemType.Mouse,
                    OwnerId = 2,
                    OwnerName = "User #2",
                    BrandId = 2,
                    BrandName = "Brand #2",
                    DeskId = 1,
                    DeskName = "Desk #1",
                },
                new Item()
                {
                    Id = 6,
                    Name = "Keyboard #6",
                    AddDate = new DateTime(2023, 12, 22, 8, 30, 28),
                    SerialNumber = "nc8cqfhd9q",
                    Status = ItemStatus.Used,
                    Type = ItemType.Keyboard,
                    OwnerId = 2,
                    OwnerName = "User #2",
                    BrandId = 2,
                    BrandName = "Brand #2",
                    DeskId = 1,
                    DeskName = "Desk #1",
                }
            };

            return _items;
        }
        public async Task<Item> GetItemByIdAsync(int id)
        {
            await Task.Delay(1000);
            var _items = GetItemsAsync();

            return _items.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddItemAsync(AddItemDto addItemDto)
        {
            await Task.Delay(2000);
            return true;
        }
        public async Task<bool> UpdateItemAsync(UpdateItemDto updateItemDto)
        {
            await Task.Delay(1000);
            return true;
        }

        public ICollection<Desk> GetDesksAsync()
        {
            var _desks = new ObservableCollection<Desk>()
            {
                new Desk()
                {
                    Id = 1,
                    Name = "Desk #1",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 2,
                    Name = "Desk #2",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 3,
                    Name = "Desk #3",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 4,
                    Name = "Desk #4",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 5,
                    Name = "Desk #5",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 6,
                    Name = "Desk #6",
                    RoomId = 2,
                    RoomName = "Room #2",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 7,
                    Name = "Desk #7",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 8,
                    Name = "Desk #8",
                    RoomId = 3,
                    RoomName = "Room #3",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 9,
                    Name = "Desk #9",
                    RoomId = 3,
                    RoomName = "Room #3",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 11,
                    Name = "Desk #11",
                    RoomId = 3, 
                    RoomName = "Room #3",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 35,
                    Name = "Desk #35",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 2,
                    StatusName = "Broken"
                },
                new Desk()
                {
                    Id = 36,
                    Name = "Desk #36",
                    RoomId = 2,
                    RoomName = "Room #2",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 37,
                    Name = "Desk #37",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 2,
                    StatusName = "Broken"
                },
            };
            return _desks;
        }
        public async Task<ObservableCollection<DeskBasicInfoDto>> GetDesksBasicInfoAsync()
        {   
            await Task.Delay(1000);
            var _desks = new ObservableCollection<DeskBasicInfoDto>()
            {
                new DeskBasicInfoDto
                {
                    Id = 1,
                    Name = "Desk #1"
                },
                new DeskBasicInfoDto
                {
                    Id = 2,
                    Name = "Desk #2"
                },
                new DeskBasicInfoDto
                {
                    Id = 3,
                    Name = "Desk #3"
                },
                new DeskBasicInfoDto
                {
                    Id = 4,
                    Name = "Desk #4"
                },
                new DeskBasicInfoDto
                {
                    Id = 5,
                    Name = "Desk #5"
                },
                new DeskBasicInfoDto
                {
                    Id = 6,
                    Name = "Desk #6"
                },
                new DeskBasicInfoDto
                {
                    Id = 7,
                    Name = "Desk #7"
                }
            };

            return _desks;
        }
        public async Task<ObservableCollection<DeskStatusDto>> GetDeskStatusesAsync()
        {
            await Task.Delay(300);

            var _statuses = new ObservableCollection<DeskStatusDto>()
            {
                new DeskStatusDto
                {
                    Id = 1,
                    Name = "Working"
                },
                new DeskStatusDto
                {
                    Id = 2,
                    Name = "Broken"
                }
            };

            return _statuses;
        }
        public async Task<Desk> GetDeskByIdAsync(int id)
        {
            await Task.Delay(300);

            var _desks = GetDesksAsync();

            return _desks.Where(e => e.Id == id).FirstOrDefault();
        }

        public async Task<ObservableCollection<RoomBasicInfoDto>> GetRoomsBasicInfoAsync()
        {
            await Task.Delay(300);

            var _rooms = new ObservableCollection<RoomBasicInfoDto>()
            {
                new RoomBasicInfoDto
                {
                    Id = 1,
                    Name = "Room #1"
                },
                new RoomBasicInfoDto
                {
                    Id = 2,
                    Name = "Room #2"
                },
                new RoomBasicInfoDto
                {
                    Id = 3,
                    Name = "Room #3"
                },
                new RoomBasicInfoDto
                {
                    Id = 4,
                    Name = "Room #4"
                },
                new RoomBasicInfoDto
                {
                    Id = 5,
                    Name = "Room #5"
                },
                new RoomBasicInfoDto
                {
                    Id = 6,
                    Name = "Room #6"
                },
                new RoomBasicInfoDto
                {
                    Id = 7,
                    Name = "Room #7"
                }
            };

            return _rooms;
        }

        public async Task<ObservableCollection<Brand>> GetBrandsAsync()
        {
            await Task.Delay(1000);
            var _brands = new ObservableCollection<Brand>()
            {
                new Brand
                {
                    Id = 1,
                    Name = "Brand #1"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Brand #2"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Brand #3"
                },
                new Brand
                {
                    Id = 4,
                    Name = "Brand #4"
                },

            };

            return _brands;
        }

        public async Task<ObservableCollection<UserBasicInfoDto>> GetUsersBasicInfoAsync()
        {
            await Task.Delay(1000);
            var _users = new ObservableCollection<UserBasicInfoDto>()
            {
                new UserBasicInfoDto
                {
                    Id = 1,
                    Name = "User #1"
                },
                new UserBasicInfoDto
                {
                    Id = 2,
                    Name = "User #2"
                },
                new UserBasicInfoDto
                {
                    Id = 3,
                    Name = "User #3"
                },
                new UserBasicInfoDto
                {
                    Id = 4,
                    Name = "User #4"
                },

            };

            return _users;
        }



        public async Task<bool> DeleteEntity(int id, EntityType type)
        {
            switch (type)
            {   
                case EntityType.Building:
                case EntityType.Desk:
                case EntityType.DeskStatus:
                case EntityType.Floor:
                case EntityType.Room:
                case EntityType.User:
                    return true;

                case EntityType.Unknown:
                    return false;

                default: return false;
            }
        }
    }
}
