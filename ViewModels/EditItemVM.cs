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

namespace WPFDeskManager.ViewModels
{
    public class EditItemVM : EntityWindowBase
    {
        private UpdateItemDto _item;
        private ObservableCollection<Brand> _brands;
        private ObservableCollection<DeskBasicInfoDto> _desks;
        private ObservableCollection<UserBasicInfoDto> _users;
        private ObservableCollection<ItemTypeComboBox> _types;
        private Brand _selectedBrand = new Brand();
        private DeskBasicInfoDto _selectedDesk = new DeskBasicInfoDto();
        private UserBasicInfoDto _selectedUser = new UserBasicInfoDto();
        private ItemTypeComboBox _selectedType = new ItemTypeComboBox();
        private string _cancelButtonContent;

        public UpdateItemDto Item
        {
            get { if (_item is null)
                    {
                        _item = new UpdateItemDto();
                    }

                    return _item; 
                }
            set { _item = value; OnPropertyChanged(); }
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
            set { _selectedBrand = value; ChangeSelectedBrand(); OnPropertyChanged(); }
        }
        public DeskBasicInfoDto SelectedDesk
        {
            get { return _selectedDesk; }
            set { _selectedDesk = value; ChangeSelectedDesk(); OnPropertyChanged(); }
        }
        public UserBasicInfoDto SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; ChangeSelectedUser(); OnPropertyChanged(); }
        }
        public ItemTypeComboBox SelectedType
        {
            get { return _selectedType; }
            set { _selectedType = value; ChangeSelectedType(); OnPropertyChanged(); }
        }
        public string CancelButtonContent
        {
            get { return _cancelButtonContent; }
            set { _cancelButtonContent = value; OnPropertyChanged(); OnPropertyChanged(); }
        }

        public override void SetWindowData()
        {
            EntityButtonContent = "OK";
            CancelButtonContent = "Anuluj";
            Types = StaticData.ItemTypes;
        }

        public override async Task LoadDataAsync()
        {

            try
            {
                this.IsLoading = true;

                var result = await _restService.GetItemByIdAsync(StaticData.CurrentEntityId);

                if (result != null)
                {
                    Item = new UpdateItemDto
                    {
                        Id = result.Id,
                        Name = result.Name,
                        SerialNumber = result.SerialNumber,
                        Status = result.Status,
                        Type = result.Type,
                        OwnerId = result.OwnerId,
                        BrandId = result.BrandId,
                        DeskId = result.DeskId,
                    };
                }

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
                SetCheckboxData();
            }
        }

        public override void EntityButtonMethod(object obj)
        {
            EditDeskAsync(obj);
        }

        private async Task EditDeskAsync(object obj)
        {
            
            this.IsLoading = true;

            try
            {
                await _restService.UpdateItemAsync(Item);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                CloseButtonMethod(obj);
                MessageBox.Show($"{Item.Id} | {Item.Name} | {Item.OwnerId} | {Item.BrandId} | {Item.DeskId} | {Item.Type}");
            }
        }
        private void SetCheckboxData()
        {
            if (Item is null)
            {
                return;
            }

            var desk = Desks.Where(e => e.Id == Item.DeskId).FirstOrDefault();

            if (desk != null)
            {
                SelectedDesk = new DeskBasicInfoDto { Id = desk.Id, Name = desk.Name };
            }

            var brand = Brands.Where(e => e.Id == Item.BrandId).FirstOrDefault();

            if (brand != null)
            {
                SelectedBrand = new Brand { Id = brand.Id, Name = brand.Name };
            }

            var user = Users.Where(e => e.Id == Item.OwnerId).FirstOrDefault();

            if (user != null)
            {
                SelectedUser = new UserBasicInfoDto { Id = user.Id, Name = user.Name };
            }

            var type = StaticData.ItemTypes.Where(e => e.ItemType == Item.Type).FirstOrDefault();

            if (type != null)
            {
                SelectedType = new ItemTypeComboBox { Id = type.Id, Name = type.Name };
            }

        }
        private void ChangeSelectedDesk()
        {
            Item.DeskId = SelectedDesk.Id;
        }

        private void ChangeSelectedBrand()
        {
            Item.BrandId = SelectedBrand.Id;
        }

        private void ChangeSelectedUser()
        {
            Item.OwnerId = SelectedUser.Id;
        }

        private void ChangeSelectedType()
        {
            Item.Type = SelectedType.ItemType;
        }
    }
}
