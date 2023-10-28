using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SWPProjekt.Commands;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private bool _interfaceChecked;
        private User _loginuser;

        public bool InterfaceChecked
        {
            get { return _interfaceChecked; }
            set { _interfaceChecked = value;
                OnPropertyChanged(nameof(InterfaceChecked));
            }
        }

        private int _fontSize;

        public int FontSize
        {
            get { return _fontSize; }
            set {
                _fontSize = value;
                OnPropertyChanged(nameof(FontSize));
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

        public MainViewModel(User LoginUser)
        {
            _loginuser = LoginUser;
            FontSize = 16;
            UpdateViewCommand = new UpdateViewCommand(this);
            ChangeInterfaceCommand = new ChangeInterfaceCommand(this);
        }
    }
}
