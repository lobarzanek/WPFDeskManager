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
    public class EditBrandVM : EntityWindowBase
    {
        private Brand _brand = new();

        public Brand Brand
        {
            get
            {
                if (_brand is null)
                {
                    _brand = new Brand();
                }

                return _brand;
            }
            set { _brand = value; OnPropertyChanged(); }
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
                Brand = await _restService.GetBrandByIdAsync(StaticData.CurrentEntityId);
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
            EditBrandAsync(obj);
        }

        private async Task EditBrandAsync(object obj)
        {
            bool result = false;
            this.IsLoading = true;

            try
            {
                result = await _restService.UpdateBrandAsync(Brand);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                if (result)
                {
                    MessageBox.Show("Updated");
                    CloseButtonMethod(obj);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
