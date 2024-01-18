using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class AddItemVM : EntityWindowBase
    {
        private AddItemDto _addItemDto;
        private ObservableCollection<Brand> _brands;
        private ObservableCollection<DeskBasicInfoDto> _desks;
        private ObservableCollection<UserBasicInfoDto> _users;
        private ObservableCollection<ItemTypeComboBox> _types;
        private Brand _selectedBrand;
        private DeskBasicInfoDto _selectedDesk;
        private UserBasicInfoDto _selectedUser;
        private ItemTypeComboBox _selectedType;

        public AddItemDto AddItemDto
        {
            get { return _addItemDto; }
            set { _addItemDto = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Brand> Brands
        {
            get { return _brands; }
            set { _brands = value; OnPropertyChanged(); }
        }
        public ObservableCollection<DeskBasicInfoDto> Desks
        {
            get { return _desks; }
            set { _desks = value; OnPropertyChanged(); }
        }
        public ObservableCollection<UserBasicInfoDto> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged(); }
        }
        public ObservableCollection<ItemTypeComboBox> Types
        {
            get { return _types; }
            set { _types = value; OnPropertyChanged(); }
        }
        public Brand SelectedBrand
        {
            get { return _selectedBrand; }
            set { _selectedBrand = value; ChangeSelectedBrand(); }
        }
        public DeskBasicInfoDto SelectedDesk
        {
            get { return _selectedDesk; }
            set { _selectedDesk = value; ChangeSelectedDesk(); }
        }
        public UserBasicInfoDto SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; ChangeSelectedUser(); }
        }
        public ItemTypeComboBox SelectedType
        {
            get { return _selectedType; }
            set { _selectedType = value; ChangeSelectedType(); }
        }

        public override void SetWindowData()
        {
            AddItemDto = new AddItemDto();
            EntityButtonContent = "Dodaj";
            Types = StaticData.ItemTypes;
        }

        public override async Task LoadDataAsync()
        {
            this.IsLoading = true;

            try
            {
                Brands = await _restService.GetBrandsAsync();
                Desks = await _restService.GetDesksBasicInfoAsync();
                Users = await _restService.GetUsersBasicInfoAsync();
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
            AddItemAsync();
        }

        private async Task AddItemAsync()
        {
            bool result = false;

            try
            {
                this.IsLoading = true;
                result = await _restService.AddItemAsync(AddItemDto);
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
        private void ChangeSelectedDesk()
        {
            AddItemDto.DeskId = SelectedDesk.Id;
        }

        private void ChangeSelectedBrand()
        {
            AddItemDto.BrandId = SelectedBrand.Id;
        }
        private void ChangeSelectedUser()
        {
            AddItemDto.OwnerId = SelectedUser.Id;
        }
        private void ChangeSelectedType()
        {
            AddItemDto.Type = SelectedType.ItemType;
        }

    }
}
