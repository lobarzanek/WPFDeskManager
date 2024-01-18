using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class AddFloorVM : EntityWindowBase
    {
        private AddFloorDto _floor = new AddFloorDto();
        private ObservableCollection<Building> _buildings = new ObservableCollection<Building>();
        private Building _selectedBuilding = new Building();

        public AddFloorDto Floor
        {
            get { return _floor; }
            set { _floor = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Building> Buildings
        {
            get { return _buildings; }
            set { _buildings = value; OnPropertyChanged(); }
        }
        public Building SelectedBuilding
        {
            get { return _selectedBuilding; }
            set { _selectedBuilding = value; ChangeSelectedBuilding(); OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            Floor = new AddFloorDto();
            EntityButtonContent = "Dodaj";
        }
        public override async Task LoadDataAsync()
        {
            this.IsLoading = true;

            try
            {
                Buildings = await _restService.GetBuildingsAsync();
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
            AddFloorAsync();
        }

        private async Task AddFloorAsync()
        {
            bool result = false;

            try
            {
                this.IsLoading = true;
                result = await _restService.AddFloorAsync(Floor);
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
        private void ChangeSelectedBuilding()
        {
            Floor.BuildingId = SelectedBuilding.Id;
        }
    }
}
