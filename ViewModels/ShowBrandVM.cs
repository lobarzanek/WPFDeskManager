using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class ShowBrandVM : EntityWindowBase
    {
        private Brand _brand = new();

        public Brand Brand
        {
            get { return _brand; }
            set { _brand = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            EntityButtonContent = "OK";
        }

        public override async Task LoadDataAsync()
        {
            this.IsLoading = true;

            try
            {
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
    }
}
