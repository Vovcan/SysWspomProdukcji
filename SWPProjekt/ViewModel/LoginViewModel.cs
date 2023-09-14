using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWPProjekt.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMassage;
        private bool _isViewVisible = true;

        public string Username
        {
            get {  return _username; }
            set 
            { 
                _username = value; 
                OnPropertyChanged(nameof(Username));
                    
            }
        }
        public SecureString Password { 
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMassage {
            get { return _errorMassage; }
            set
            {
                _errorMassage = value;
                OnPropertyChanged(nameof(ErrorMassage));
            }
        
        }
        public bool IsViewVisible { 
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }

        // Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }

        public ICommand ShowPasswordCommand { get; }

        public ICommand RememberPasswordCommand { get; }
        //Constructor
        public LoginViewModel()
        {
            LoginCommand = new CommandsViewModel(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new CommandsViewModel(p => ExecuteRecoverPassCommand("",""));
        }


        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if(string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }
        private void ExecuteRecoverPassCommand(string username, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
