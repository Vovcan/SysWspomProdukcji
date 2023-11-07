using System.Windows.Input;
using System.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System.Runtime.InteropServices;
using System;
using System.ComponentModel;
using SWPProjekt.ViewModel;
using SWPProjekt.View;
using System.Windows;
using System.Windows.Navigation;
using SWPProjekt;
using System.Windows.Controls;

public class LoginViewModel : BaseViewModel
{
    public static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            var a = Convert.ToHexString(hashBytes);
            return a; // .NET 5 +
        }
    }
    private string _username;
    private string _password;
    private User _loginuser;
    public string Username
    {
        get { return _username; }
        set 
        { 
            _username = value; 
        }
    }
    public string Password
    {
        get { return _password; }  
        set { 
            _password = value; 
        }
    }

    public RelayCommand LoginCommand { get; set; }

    public RelayCommand PasswordRecoveryCommand { get; set; }
    public User LoginUser 
    {
        get { 
            return _loginuser; 
        }
        set { 
            _loginuser = value;
        }
    }
    private UserControl _currentView;

    public UserControl CurrentView
    {
        get { return _currentView; }
        set
        {
            _currentView = value;
            OnPropertyChanged(nameof(CurrentView));
        }
    }
    private void OnLogin(object a)
    {

        using (var context = new ProductionDatabaseContext())
        {
            var user = context.Users.FirstOrDefault(u => u.Login == Username && u.Password == CreateMD5(Password));
            if(user.TemporaryPassword == 1)
            {
                var tworzenienowegohasla = new TworzenieNowegoHasla(user.Email);
                CurrentView = tworzenienowegohasla;
            }
            else if(user != null)
            {
                _loginuser = user;
                Window loginWindow = Application.Current.Windows.OfType<Login>().FirstOrDefault();

                // open new window MainWindow.xaml
                var mainWindow = new MainWindow(_loginuser);

                mainWindow.Show();
                // close Login.xaml
                loginWindow.Close();
            }else
            {
                MessageBox.Show("Failed");
            }
        }


    }
    
    private void OpenForgetPasswordView(object a)
    {
        var passwordRecoveryPage = new OdzyskanieHasla();
        CurrentView = passwordRecoveryPage;
    }
    public LoginViewModel()
    {
        LoginCommand = new RelayCommand(OnLogin);
        PasswordRecoveryCommand = new RelayCommand(OpenForgetPasswordView);
        CurrentView = new LoginStartPage();
    }

}
