using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;

namespace WPFDeskManager.ViewModels
{
    public class DesksVM : ViewModelBase
    {
        private readonly RestService _restService = new RestService();

        public string PageTitle { get; set; }
        public ObservableCollection<Desk> Desks { get; set; }

        public DesksVM()
        {
            Initialize();
        }

        private void Initialize()
        {
            Desks = (ObservableCollection<Desk>)_restService.GetDesks();

            PageTitle = $"Desks: {Desks.Count}";
        }
    }
}
