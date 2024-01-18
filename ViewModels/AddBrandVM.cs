using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Utilities.Base;

namespace WPFDeskManager.ViewModels
{
    public class AddBrandVM : EntityWindowBase
    {
        private AddBrandDto _brand = new();

        public AddBrandDto Brand
        {
            get { return _brand; }
            set { _brand = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            EntityButtonContent = "Dodaj";
        }

        public override void EntityButtonMethod(object obj)
        {
            AddBrandAsync();
        }

        private async Task AddBrandAsync()
        {
            bool result = false;

            try
            {
                this.IsLoading = true;
                result = await _restService.AddBrandAsync(Brand);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                if (result)
                {
                    MessageBox.Show("Added");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
