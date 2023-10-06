﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SWPProjekt.ViewModel;

namespace SWPProjekt.Commands
{
    internal class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            
            if (parameter.ToString() == "WarehouseList")
            {
                viewModel.SelectedViewModel = new WarehouseListScreenViewModel();
            }else if(parameter.ToString() == "ProductionList")
            {
                viewModel.SelectedViewModel = new ProductionListScreenViewModel();
            }
            else if (parameter.ToString() == "ArchiveScreen")
            {
                viewModel.SelectedViewModel = new ArchiveScreenViewModel();
            }
            else if (parameter.ToString() == "ComplaintsScreen")
            {
                viewModel.SelectedViewModel = new ComplaintsScreenViewModel();
            }
            else if (parameter.ToString() == "EmployeeListScreen")
            {
                viewModel.SelectedViewModel = new EmployeeListScreenViewModel();
            }
            else if (parameter.ToString() == "HoursScreen")
            {
                viewModel.SelectedViewModel = new HoursScreenViewModel();
            }
            else if (parameter.ToString() == "ProjectsScreen")
            {
                viewModel.SelectedViewModel = new ProjectsScreenViewModel();
            }
            else if (parameter.ToString() == "SaleScreen")
            {
                viewModel.SelectedViewModel = new SaleScreenViewModel();
            }
            else if (parameter.ToString() == "SettingsScreen")
            {
                viewModel.SelectedViewModel = new SettingsScreenViewModel();
            }
        }
    }
}