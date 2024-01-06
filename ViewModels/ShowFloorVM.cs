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
    public class ShowFloorVM : EntityWindowBase
    {
        private Floor _floor;

        public Floor Floor
        {
            get { return _floor; }
            set { _floor = value; OnPropertyChanged(); }
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
                Floor = await _restService.GetFloorByIdAsync(StaticData.CurrentEntityId);
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
