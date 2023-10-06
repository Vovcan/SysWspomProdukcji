using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SWPProjekt.Commands;

namespace SWPProjekt.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        private bool _interfaceChecked;

        public bool InterfaceChecked
        {
            get { return _interfaceChecked; }
            set { _interfaceChecked = value;
                OnPropertyChanged(nameof(InterfaceChecked));
            }
        }

        public ICommand ChangeInterfaceCommand { get; set; }

        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { 
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            ChangeInterfaceCommand = new ChangeInterfaceCommand(this);
        }
    }
}
