using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Views;

namespace WPFDeskManager.Utilities
{
    public abstract class EntityWindowBase : ViewModelBase
    {
        public readonly RestService _restService = new RestService();

        public ICommand EntityButtonCommand { get; set; }
        public ICommand CloseButtonCommand { get; set; }
        public string EntityButtonContent { get; set; }
        

        public EntityWindowBase()
        {
            Initialize();
        }

        public void Initialize()
        {
            
            EntityButtonCommand = new RelayCommand(EntityButtonMethod, CanExecutableEntityButtonMethod);
            CloseButtonCommand = new RelayCommand(CloseButtonMethod, CanExecutableCloseButtonMethod);
            LoadDataAsync();
            SetWindowData();
        }

        public virtual void SetWindowData()
        {
            return;
        }

        public virtual Task LoadDataAsync()
        {
            return Task.CompletedTask;
        }

        public virtual bool CanExecutableEntityButtonMethod(object arg)
        {
            return true;
        }

        public virtual void EntityButtonMethod(object obj)
        {
            return;
        }

        public bool CanExecutableCloseButtonMethod(object arg)
        {
            return true;
        }

        public void CloseButtonMethod(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
