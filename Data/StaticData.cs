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
                };
            }
        }
        public static int CurrentEntityId;
    }
}
