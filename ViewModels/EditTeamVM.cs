using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;

namespace WPFDeskManager.ViewModels
{
    public class EditTeamVM : EntityWindowBase
    {
        private Team _team = new();

        public Team Team
        {
            get
            {
                if (_team is null)
                {
                    _team = new Team();
                }

                return _team;
            }
            set { _team = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            EntityButtonContent = "OK";
            CancelButtonContent = "Anuluj";
        }
        public override async Task LoadDataAsync()
        {

            try
            {
                this.IsLoading = true;
                Team = await _restService.GetTeamByIdAsync(StaticData.CurrentEntityId);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
            }
        }
        public override void EntityButtonMethod(object obj)
        {
            EditTeamAsync(obj);
        }

        private async Task EditTeamAsync(object obj)
        {
            bool result = false;
            this.IsLoading = true;

            try
            {
                result = await _restService.UpdateTeamAsync(Team);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                if (result)
                {
                    MessageBox.Show("Updated");
                    CloseButtonMethod(obj);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
