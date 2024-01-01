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
    }
}
