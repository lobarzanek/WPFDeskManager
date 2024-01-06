using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class DeleteEntityVM : EntityWindowBase
    {
        private string _entityName = "";
        private EntityType _entityType;

        public string EntityName
        {
            get { return _entityName; }
            set { _entityName = value; OnPropertyChanged(); }
        }

        public EntityType EntityType
        {
            get { return _entityType; }
            set { _entityType = value; OnPropertyChanged(); }
        }

        public override void SetWindowData()
        {
            EntityButtonContent = "Usuń";
            CancelButtonContent = "Anuluj";
        }

        public override void EntityButtonMethod(object obj)
        {
            SendDeleteEntity(obj);            
        }

        private async Task SendDeleteEntity(object obj)
        {
            this.IsLoading = true;

            try
            {
                await Task.Delay(2000);
                await _restService.DeleteEntity(EntityId, EntityType);
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = false;
                CloseButtonMethod(obj);
            }
        }
    }
}
