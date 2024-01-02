using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;

namespace WPFDeskManager.ViewModels
{
    public class DesksVM : ViewModelBase
    {
        private readonly RestService _restService = new RestService();
        private ObservableCollection<Desk> _desks;

        public string PageTitle { get; set; }
        public ObservableCollection<Desk> Desks 
        { 
            get { return _desks; } 
            set { _desks = value; OnPropertyChanged(); } 
        }

        public DesksVM()
        {
            Initialize();
        }

        private void Initialize()
        {
            LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                await Task.Delay(2000);
                Desks = (ObservableCollection<Desk>)_restService.GetDesks();
                PageTitle = $"Desks: {Desks.Count}";

            }
            catch (Exception ex)
            {

            }
            finally 
            { 
                IsLoading = false; 
            }
        }


    }
}
