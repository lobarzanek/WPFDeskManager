using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Models;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class AddBuildingVM : EntityWindowBase
    {
        private AddBuildingDto _building;

        public AddBuildingDto Building
        {
            get { return _building; }
            set { _building = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            Building = new AddBuildingDto();
            EntityButtonContent = "Dodaj";
        }
        
        public override void EntityButtonMethod(object obj)
        {
            AddBuildingAsync();
        }

        private async Task AddBuildingAsync()
        {
            bool result = false;

            try
            {
                this.IsLoading = true;
                result = await _restService.AddBuildingAsync(Building);
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
