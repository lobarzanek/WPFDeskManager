using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDeskManager.Models;

namespace WPFDeskManager.Data
{
    public static class StaticData
    {
        public static ObservableCollection<ItemTypeComboBox> ItemTypes
        {
            get {
                return new ObservableCollection<ItemTypeComboBox>
                {
                    new ItemTypeComboBox
                    {
                        Id= 0,
                        Name = "Inny",
                        ItemType = ItemType.Other
                    },
                    new ItemTypeComboBox
                    {
                        Id= 2,
                        Name = "Myszka",
                        ItemType = ItemType.Mouse
                    },
                    new ItemTypeComboBox
                    {
                        Id= 3,
                        Name = "Klawiatura",
                        ItemType = ItemType.Keyboard
                    },
                    new ItemTypeComboBox
                    {
                        Id= 4,
                        Name = "Monitor",
                        ItemType = ItemType.Monitor
                    },
                    new ItemTypeComboBox
                    {
                        Id= 4,
                        Name = "Stacja Dokująca",
                        ItemType = ItemType.DockStation
                    },
                };
            }
        }
        public static ObservableCollection<RoleComboBox> Roles
        {
            get
            {
                return new ObservableCollection<RoleComboBox>
                {
                    new RoleComboBox
                    {
                        Id= 0,
                        Name = "Admin",
                        Role = Role.Admin
                    },
                    new RoleComboBox
                    {
                        Id= 1,
                        Name = "User",
                        Role = Role.User
                    },
                };
            }
        }

        public static ObservableCollection<DeskStatusComboBox> DeskStatuses
        {
            get
            {
                return new ObservableCollection<DeskStatusComboBox>
                {
                    new DeskStatusComboBox
                    {
                        Id= 0,
                        Name = "Free",
                        DeskStatus = DeskStatus.Free
                    },
                    new DeskStatusComboBox
                    {
                        Id= 2,
                        Name = "Broken",
                        DeskStatus = DeskStatus.Broken
                    },
                };
            }
        }
        public static int CurrentEntityId { get; set; }
    }
}
