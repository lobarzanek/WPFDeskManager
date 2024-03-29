﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFDeskManager.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Utilities;
using WPFDeskManager.Utilities.Base;
using WPFDeskManager.Views;

namespace WPFDeskManager.ViewModels
{
    public class DesksVM : ViewModelBase
    {
        private ObservableCollection<Desk> _desks;               

        public ObservableCollection<Desk> Desks 
        { 
            get { return _desks; } 
            set { _desks = value; OnPropertyChanged(); } 
        }

        public override async Task LoadDataAsync()
        {
            IsLoading = true;

            try
            {
                Desks = await _restService.GetDesksAsync();
                PageTitle = $"Desks: {Desks.Count}";
                AddButtonContent = "Dodaj biurko";

            }
            catch (Exception ex)
            {

            }
            finally 
            { 
                IsLoading = false; 
            }
        }

        public override void ShowAddWindow(object obj)
        {
            AddDesk addDeskWindow = new AddDesk();
            addDeskWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addDeskWindow.Show();
        }

        public override void ShowCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            ShowDesk showDeskWindow = new ShowDesk();
            showDeskWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            showDeskWindow.Show();
        }

        public override void DeleteCommandExecute(object parameter)
        {
            var values = (object[])parameter;
            var id = (int)values[0];
            var name = (string)values[1];

            DeleteEntityVM deleteEntityVM = new DeleteEntityVM();
            deleteEntityVM.EntityId = id;
            deleteEntityVM.EntityName = name;
            deleteEntityVM.EntityType = EntityType.Desk;

            DeleteEntity deleteEntityWindow = new DeleteEntity();
            deleteEntityWindow.DataContext = deleteEntityVM;
            deleteEntityWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            deleteEntityWindow.Show();
        }

        public override void EditCommandExecute(object parameter)
        {
            StaticData.CurrentEntityId = (int)parameter;

            EditDesk editDeskWindow = new EditDesk();
            editDeskWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editDeskWindow.Show();
        }

    }
}
