using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDeskManager.Models;

namespace WPFDeskManager.Data
{
    public class RestService
    {
        public RestService()
        {

        }

        public ICollection<Item> GetItems()
        {

            var _items = new ObservableCollection<Item>() {
                new Item()
                {
                    Id = 1,
                    Name = "Mouse#1",
                    AddDate = new DateTime(2023, 12, 21, 5, 10, 20),
                    SerialNumber = "abc123def456",
                    Status = ItemStatus.Free,
                    Type = ItemType.Mouse,
                    OwnerId = 1,
                    OwnerName = "John",
                    BrandId = 1,
                    BrandName = "Asus",
                    DeskId = null,
                    DeskName = null,
                },
                new Item()
                {
                    Id = 2,
                    Name = "Mouse#2",
                    AddDate = new DateTime(2023, 12, 22, 6, 30, 28),
                    SerialNumber = "m8c32nac09c",
                    Status = ItemStatus.Used,
                    Type = ItemType.Mouse,
                    OwnerId = 2,
                    OwnerName = "Alice",
                    BrandId = 2,
                    BrandName = "Razer",
                    DeskId = 1,
                    DeskName = "Desk#1",
                },
                new Item()
                {
                    Id = 3,
                    Name = "keyboard#1",
                    AddDate = new DateTime(2023, 12, 22, 8, 30, 28),
                    SerialNumber = "nc8cqfhd9q",
                    Status = ItemStatus.Used,
                    Type = ItemType.Keyboard,
                    OwnerId = 2,
                    OwnerName = "Alice",
                    BrandId = 2,
                    BrandName = "Razer",
                    DeskId = 1,
                    DeskName = "Desk#1",
                },new Item()
                {
                    Id = 4,
                    Name = "Mouse#1",
                    AddDate = new DateTime(2023, 12, 21, 5, 10, 20),
                    SerialNumber = "abc123def456",
                    Status = ItemStatus.Free,
                    Type = ItemType.Mouse,
                    OwnerId = 1,
                    OwnerName = "John",
                    BrandId = 1,
                    BrandName = "Asus",
                    DeskId = null,
                    DeskName = null,
                },
                new Item()
                {
                    Id = 5,
                    Name = "Mouse#2",
                    AddDate = new DateTime(2023, 12, 22, 6, 30, 28),
                    SerialNumber = "m8c32nac09c",
                    Status = ItemStatus.Used,
                    Type = ItemType.Mouse,
                    OwnerId = 2,
                    OwnerName = "Alice",
                    BrandId = 2,
                    BrandName = "Razer",
                    DeskId = 1,
                    DeskName = "Desk#1",
                },
                new Item()
                {
                    Id = 6,
                    Name = "keyboard#1",
                    AddDate = new DateTime(2023, 12, 22, 8, 30, 28),
                    SerialNumber = "nc8cqfhd9q",
                    Status = ItemStatus.Used,
                    Type = ItemType.Keyboard,
                    OwnerId = 2,
                    OwnerName = "Alice",
                    BrandId = 2,
                    BrandName = "Razer",
                    DeskId = 1,
                    DeskName = "Desk#1",
                },new Item()
                {
                    Id = 7,
                    Name = "Mouse#1",
                    AddDate = new DateTime(2023, 12, 21, 5, 10, 20),
                    SerialNumber = "abc123def456",
                    Status = ItemStatus.Free,
                    Type = ItemType.Mouse,
                    OwnerId = 1,
                    OwnerName = "John",
                    BrandId = 1,
                    BrandName = "Asus",
                    DeskId = null,
                    DeskName = null,
                },
                new Item()
                {
                    Id = 8,
                    Name = "Mouse#2",
                    AddDate = new DateTime(2023, 12, 22, 6, 30, 28),
                    SerialNumber = "m8c32nac09c",
                    Status = ItemStatus.Used,
                    Type = ItemType.Mouse,
                    OwnerId = 2,
                    OwnerName = "Alice",
                    BrandId = 2,
                    BrandName = "Razer",
                    DeskId = 1,
                    DeskName = "Desk#1",
                },
                new Item()
                {
                    Id = 9,
                    Name = "keyboard#1",
                    AddDate = new DateTime(2023, 12, 22, 8, 30, 28),
                    SerialNumber = "nc8cqfhd9q",
                    Status = ItemStatus.Used,
                    Type = ItemType.Keyboard,
                    OwnerId = 2,
                    OwnerName = "Alice",
                    BrandId = 2,
                    BrandName = "Razer",
                    DeskId = 1,
                    DeskName = "Desk#1",
                },new Item()
                {
                    Id = 10,
                    Name = "Mouse#1",
                    AddDate = new DateTime(2023, 12, 21, 5, 10, 20),
                    SerialNumber = "abc123def456",
                    Status = ItemStatus.Free,
                    Type = ItemType.Mouse,
                    OwnerId = 1,
                    OwnerName = "John",
                    BrandId = 1,
                    BrandName = "Asus",
                    DeskId = null,
                    DeskName = null,
                }
            };

            return _items;
        }

        public ICollection<Desk> GetDesks()
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
    }
}
