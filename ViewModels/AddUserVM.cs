using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDeskManager.Data;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;
using System.Windows;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class AddUserVM : EntityWindowBase
    {
        private AddUserDto _user = new();
        private ObservableCollection<RoleComboBox> _roles = StaticData.Roles;
        private ObservableCollection<Team> _teams = new();
        private RoleComboBox _selectedRole = new();
        private Team _selectedTeam = new();

        public AddUserDto User
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
            EntityButtonContent = "Dodaj";
        }
        public override async Task LoadDataAsync()
        {
            this.IsLoading = true;

            try
            {
                Teams = await _restService.GetTeamsAsync();
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
            AddUserAsync();
        }

        private async Task AddUserAsync()
        {
            bool result = false;

            try
            {
                this.IsLoading = true;
                result = await _restService.AddUserAsync(User);
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
