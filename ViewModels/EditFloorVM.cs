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
    public class EditFloorVM : EntityWindowBase
    {
        private UpdateFloorDto _floor;
        private ObservableCollection<Building> _buildings;
        private Building _selectedBuilding;
        private string _cancelButtonContent;

        public UpdateFloorDto Floor
        {
            get
            {
                if (_floor is null)
                {
                    _floor = new UpdateFloorDto();
                }

                return _floor;
            }
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
        public string CancelButtonContent
        {
            get { return _cancelButtonContent; }
            set { _cancelButtonContent = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            EntityButtonContent = "OK";
            CancelButtonContent = "Anuluj";
        }
        public override async Task LoadDataAsync()
        {

            try
            {
                this.IsLoading = true;

                var result = await _restService.GetFloorByIdAsync(StaticData.CurrentEntityId);

                if (result != null)
                {
                    Floor = new UpdateFloorDto
                    {
                        Id = result.Id,
                        Name = result.Name,
                        BuildingId = result.BuildingId,
                    };
                }

                Buildings = await _restService.GetBuildingsAsync();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                SetCheckboxData();
            }
        }
        public override void EntityButtonMethod(object obj)
        {
            EditFloorAsync(obj);
        }

        private async Task EditFloorAsync(object obj)
        {

            this.IsLoading = true;

            try
            {
                await _restService.UpdateFloorAsync(Floor);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                CloseButtonMethod(obj);
                MessageBox.Show($"{Floor.Id} | {Floor.Name} | {Floor.BuildingId}");
            }
        }
        private void SetCheckboxData()
        {
            if (Floor is null)
            {
                return;
            }

            var building = Buildings.Where(e => e.Id == Floor.BuildingId).FirstOrDefault();

            if (building != null)
            {
                SelectedBuilding = building;
            }
        }
        private void ChangeSelectedBuilding()
        {
            Floor.BuildingId = SelectedBuilding.Id;
        }
    }
}
