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

namespace WPFDeskManager.ViewModels
{
    public class AddDeskStatusVM : EntityWindowBase
    {
        private AddDeskStatusDto _addDeskStatusDto;

        public AddDeskStatusDto AddDeskStatusDto
        {
            get { return _addDeskStatusDto; }
            set { _addDeskStatusDto = value; OnPropertyChanged(); }
        }
        public override void SetWindowData()
        {
            AddDeskStatusDto = new AddDeskStatusDto();
            EntityButtonContent = "Dodaj";
        }

        public override void EntityButtonMethod(object obj)
        {
            AddDeskStatusAsync();
        }

        private async Task AddDeskStatusAsync()
        {
            bool result = false;

            try
            {
                this.IsLoading = true;
                result = await _restService.AddDeskStatusAsync(AddDeskStatusDto);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsLoading = !result;
                if(result == true)
                {
                    MessageBox.Show($"Added {AddDeskStatusDto.Name}");
                }
            }
        }
    }
}
