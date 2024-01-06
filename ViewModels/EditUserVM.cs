using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class EditUserVM : EntityWindowBase
    {
        private UpdateUserDto _user = new();
        private ObservableCollection<RoleComboBox> _roles = StaticData.Roles;
        private ObservableCollection<Team> _teams = new();
        private RoleComboBox _selectedRole = new();
        private Team _selectedTeam = new();

        public UpdateUserDto User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }
        public ObservableCollection<RoleComboBox> Roles
        {
            get { return _roles; }
            set { _roles = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Team> Teams
        {
            get { return _teams; }
            set { _teams = value; OnPropertyChanged(); }
        }
        public RoleComboBox SelectedRole
        {
            get { return _selectedRole; }
            set { _selectedRole = value; ChangeSelectedRole(); OnPropertyChanged(); }
        }
        public Team SelectedTeam
        {
            get { return _selectedTeam; }
            set { _selectedTeam = value; ChangeSelectedTeam(); OnPropertyChanged(); }
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

                var result = await _restService.GetUserByIdAsync(StaticData.CurrentEntityId);

                if (result != null)
                {
                    User = new UpdateUserDto
                    {
                        Id = result.Id,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        Login = result.Login,
                        RoleId = result.RoleId,
                        TeamId = result.TeamId,
                    };
                }

                Teams = await _restService.GetTeamsAsync();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                SetCheckboxData();
            }
        }
        private void SetCheckboxData()
        {
            if (User is null)
            {
                return;
            }

            var team = Teams.Where(e => e.Id == User.TeamId).FirstOrDefault();

            if (team != null)
            {
                SelectedTeam = team;
            }

            var role = Roles.Where(e => e.Role == User.RoleId).FirstOrDefault();

            if (role != null)
            {
                SelectedRole = role;
            }
        }
        private void ChangeSelectedTeam()
        {
            User.TeamId = SelectedTeam.Id;
        }

        private void ChangeSelectedRole()
        {
            User.RoleId = SelectedRole.Role;
        }
    }
}
