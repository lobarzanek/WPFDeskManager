using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class EditDeskStatusVM : EntityWindowBase
    {
        private DeskStatus _deskStatus;
        private string _cancelButtonContent;

        public DeskStatus DeskStatus
        {
            get
            {
                if (_deskStatus is null)
                {
                    _deskStatus = new DeskStatus();
                }

                return _deskStatus;
            }
            set { _deskStatus = value; OnPropertyChanged(); }
        }
        public string CancelButtonContent
        {
            get { return _cancelButtonContent; }
            set { _cancelButtonContent = value; OnPropertyChanged(); }
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

                DeskStatus = await _restService.GetDeskStatusByIdAsync(StaticData.CurrentEntityId);
                
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
            EditDeskStatusAsync(obj);
        }
        private async Task EditDeskStatusAsync(object obj)
        {

            this.IsLoading = true;

            try
            {
                await _restService.UpdateDeskStatusAsync(DeskStatus);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                CloseButtonMethod(obj);
                MessageBox.Show($"{DeskStatus.Id} | {DeskStatus.Name}");
            }
        }
    }
}
