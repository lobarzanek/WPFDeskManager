using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFDeskManager.Data;

namespace WPFDeskManager.Utilities.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private bool _isLoading;
        private string _addButtonContent;
        private int _entityId;
        private string _pageTitle;
        public readonly RestService _restService = new RestService();


        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ShowAddWindowCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(); }
        }
        public string AddButtonContent
        {
            get { return _addButtonContent; }
            set { _addButtonContent = value; OnPropertyChanged(); }
        }
        public string PageTitle
        {
            get { return _pageTitle; }
            set { _pageTitle = value; OnPropertyChanged(); }
        }
        public int EntityId
        {
            get { return _entityId; }
            set { _entityId = value; OnPropertyChanged(); }
        }

        public ViewModelBase()
        {
            ShowAddWindowCommand = new RelayCommand(ShowAddWindow);
            ShowCommand = new RelayCommand(ShowCommandExecute);
            EditCommand = new RelayCommand(EditCommandExecute);
            DeleteCommand = new RelayCommand(DeleteCommandExecute);

            Initialize();
        }

        public virtual void Initialize()
        {
            LoadDataAsync();
            SetWindowData();
        }

        public virtual void SetWindowData()
        {
        }

        public virtual async Task LoadDataAsync()
        {
        }

        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public virtual void ShowAddWindow(object obj) { }
        public virtual void ShowCommandExecute(object parameter) { }

        public virtual void EditCommandExecute(object parameter) { }

        public virtual void DeleteCommandExecute(object parameter) { }


    }
}
