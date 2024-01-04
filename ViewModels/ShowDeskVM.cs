using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;

namespace WPFDeskManager.ViewModels
{
    public class ShowDeskVM : EntityWindowBase
    {
        private Desk _desk;
        
        public Desk Desk
        {
            get { return _desk; }
            set { _desk = value; OnPropertyChanged(); }
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
                await Task.Delay(2000);
                Desk = _restService.GetDeskById(EntityId);
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
