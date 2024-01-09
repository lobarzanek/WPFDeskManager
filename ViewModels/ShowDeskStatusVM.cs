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
    public class ShowDeskStatusVM : EntityWindowBase
    {
        private DeskStatus _deskStatus;

        public DeskStatus DeskStatus
        {
            get { return _deskStatus; }
            set { _deskStatus = value; OnPropertyChanged(); }
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
                DeskStatus = await _restService.GetDeskStatusByIdAsync(StaticData.CurrentEntityId);
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
