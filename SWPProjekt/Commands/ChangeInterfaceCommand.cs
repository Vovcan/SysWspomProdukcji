using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using SWPProjekt.ViewModel;

namespace SWPProjekt.Commands
{
    internal class ChangeInterfaceCommand : ICommand
    {
        private MainViewModel viewModel;
        public ChangeInterfaceCommand(MainViewModel viewModel)
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
            PaletteHelper helper = new PaletteHelper();
            ITheme theme = helper.GetTheme();

            if (viewModel.InterfaceChecked==true)
            {
                theme.SetBaseTheme(Theme.Dark);
            }
            else
            {
                theme.SetBaseTheme(Theme.Light);
            }

            helper.SetTheme(theme);
        }
    }
}
