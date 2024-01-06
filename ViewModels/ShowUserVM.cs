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
    public class ShowUserVM : EntityWindowBase
    {
        private User _user = new();

        public User User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
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
                User = await _restService.GetUserByIdAsync(StaticData.CurrentEntityId);
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
