using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    internal class NewAccountViewModel : BaseViewModel
    {
        User LoginUser;
        public MainViewModel MainModel { get; set; }
        public NewAccountViewModel(MainViewModel mainModel, User loginUser)
        {
            MainModel = mainModel;
            LoginUser = loginUser;
        }

        

    }
}
