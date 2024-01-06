using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class ItemsVM : ViewModelBase
    {
        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public string _nameTableHeader;
        private string _serialTableHeader;
        private string _typeTableHeader;
        private string _statusTableHeader;
        private string _ownerTableHeader;

        public ObservableCollection<Item> Items {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }
        public string NameTableHeader
        {
            get { return _nameTableHeader; }
            set { _nameTableHeader = value; OnPropertyChanged(); }
        }
        public string SerialTableHeader
        {
            get { return _serialTableHeader; }
            set { _serialTableHeader = value; OnPropertyChanged(); }
        }
        public string TypeTableHeader
        {
            get { return _typeTableHeader; }
            set { _typeTableHeader = value; OnPropertyChanged(); }
        }
        public string StatusTableHeader
        {
            get { return _statusTableHeader; }
            set { _statusTableHeader = value; OnPropertyChanged(); }
        }
        public string OwnerTableHeader
        {
            get { return _ownerTableHeader; }
            set { _ownerTableHeader = value; OnPropertyChanged(); }
        }

        public ItemsVM()
        {
            Initialize();
        }

        public override void SetWindowData()
        {
            NameTableHeader = "Nazwa";
            SerialTableHeader = "Numer seryjny";
            TypeTableHeader = "Typ";
            StatusTableHeader = "Status";
            OwnerTableHeader = "Właściciel";
        }

        public override async Task LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                await Task.Delay(2000);
                Items = (ObservableCollection<Item>)_restService.GetItemsAsync();
                PageTitle = $"Wyposażenie: {Items.Count}";
                AddButtonContent = "Dodaj wyposażenie";

            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsLoading = false;
            }
        }

        public override void ShowAddWindow(object obj)
        {
            AddItem addItemWindow = new AddItem();
            addItemWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addItemWindow.Show();
        }

        public override void ShowCommandExecute(object parameter)
        {
            ShowItemVM showItemVM = new ShowItemVM();
            showItemVM.EntityId = (int)parameter;

            ShowItem showItemWindow = new ShowItem();
            showItemWindow.DataContext = showItemVM;
            showItemWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            showItemWindow.Show();
        }

        public override void DeleteCommandExecute(object parameter)
        {
            var values = (object[])parameter;
            var id = (int)values[0];
            var name = (string)values[1];

            DeleteEntityVM deleteEntityVM = new DeleteEntityVM();
            deleteEntityVM.EntityId = id;
            deleteEntityVM.EntityName = name;
            deleteEntityVM.EntityType = EntityType.Item;

            DeleteEntity deleteEntityWindow = new DeleteEntity();
            deleteEntityWindow.DataContext = deleteEntityVM;
            deleteEntityWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            deleteEntityWindow.Show();
        }

        public override void EditCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            EditItem editItemWindow = new EditItem();
            editItemWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editItemWindow.Show();
        }
    }
}
