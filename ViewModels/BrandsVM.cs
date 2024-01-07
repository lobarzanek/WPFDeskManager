using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class BrandsVM : ViewModelBase
    {
        private string _nameTableHeader = "";
        private ObservableCollection<Brand> _brands = new();

        public ObservableCollection<Brand> Brands
        {
            get { return _brands; }
            set { _brands = value; OnPropertyChanged(); }
        }
        public string NameTableHeader
        {
            get { return _nameTableHeader; }
            set { _nameTableHeader = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            NameTableHeader = "Nazwa";
            AddButtonContent = "Dodaj marke";
        }
        public override async Task LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                Brands = await _restService.GetBrandsAsync();
                PageTitle = $"Marki: {Brands.Count}";
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
            AddBrand addWindow = new AddBrand();
            addWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addWindow.Show();
        }

        public override void ShowCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            ShowBrand showWindow = new ShowBrand();
            showWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            showWindow.Show();
        }

        public override void DeleteCommandExecute(object parameter)
        {
            var values = (object[])parameter;
            var id = (int)values[0];
            var name = (string)values[1];

            DeleteEntityVM deleteEntityVM = new DeleteEntityVM();
            deleteEntityVM.EntityId = id;
            deleteEntityVM.EntityName = name;
            deleteEntityVM.EntityType = EntityType.Brand;

            DeleteEntity deleteEntityWindow = new DeleteEntity();
            deleteEntityWindow.DataContext = deleteEntityVM;
            deleteEntityWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            deleteEntityWindow.Show();
        }

        public override void EditCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            EditBrand editWindow = new EditBrand();
            editWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editWindow.Show();
        }
    }
}
