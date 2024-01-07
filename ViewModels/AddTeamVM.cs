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
    public class AddTeamVM : EntityWindowBase
    {
        private AddTeamDto _team;

        public AddTeamDto Team
        {
            get { return _team; }
            set { _team = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            EntityButtonContent = "Dodaj";
        }

        public override void EntityButtonMethod(object obj)
        {
            AddTeamAsync();
        }

        private async Task AddTeamAsync()
        {
            bool result = false;

            try
            {
                this.IsLoading = true;
                result = await _restService.AddTeamAsync(Team);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = !result;
                if (result)
                {
                    MessageBox.Show("Added");
                }
            }
        }
    }
}
