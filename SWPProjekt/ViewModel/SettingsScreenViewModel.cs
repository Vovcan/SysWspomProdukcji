using SWPProjekt.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWPProjekt.ViewModel
{
    class SettingsScreenViewModel : BaseViewModel
    {

        public ICommand ChangeInterfaceCommand { get; set; }
        public SettingsScreenViewModel(MainViewModel mainModel)
        {
            MainModel = mainModel;
            ChangeInterfaceCommand = new ChangeInterfaceCommand(MainModel);
        }

        public MainViewModel MainModel { get; set; }
    }
}
