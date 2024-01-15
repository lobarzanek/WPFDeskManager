using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;

namespace WPFDeskManager.ViewModels
{
    public class ShowRoomVM : EntityWindowBase
    {
        private Room _room = new();

        public Room Room
        {
            get { return _room; }
            set { _room = value; OnPropertyChanged(); }
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
                Room = await _restService.GetRoomByIdAsync(StaticData.CurrentEntityId);
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
