using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class EditBuildingVM : EntityWindowBase
    {
        private Building _building;

        public Building Building
        {
            get
            {
                if (_building is null)
                {
                    _building = new Building();
                }

                return _building;
            }
            set { _building = value; OnPropertyChanged(); }
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
                Building = await _restService.GetBuildingByIdAsync(StaticData.CurrentEntityId);
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
            EditBuildingAsync(obj);
        }

        private async Task EditBuildingAsync(object obj)
        {

            this.IsLoading = true;

            try
            {
                await _restService.UpdateBuildingAsync(Building);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                CloseButtonMethod(obj);
                MessageBox.Show($"{Building.Id} | {Building.Name}");
            }
        }
    }
}
