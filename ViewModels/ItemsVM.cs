using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;

namespace WPFDeskManager.ViewModels
{
    public class ItemsVM : ViewModelBase
    {
        private readonly RestService _restService = new RestService();
        
        public string PageTitle { get; set; }
        public ObservableCollection<Item> Items { get; set; }

        public ItemsVM()
        {
            Initialize();
        }

        private void Initialize()
        {
            PageTitle = "Items";
            Items = (ObservableCollection<Item>)_restService.GetItems();
        }
    }
}
