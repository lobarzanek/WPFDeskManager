using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;

namespace WPFDeskManager.ViewModels
{
    public class ShowItemVM : EntityWindowBase
    {
        private Item _item;

        public Item Item
        {
            get { return _item; }
            set { _item = value; OnPropertyChanged(); }
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
                Item = await _restService.GetItemByIdAsync(EntityId);
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
