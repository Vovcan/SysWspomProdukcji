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


    public LoginViewModel()
    {
        LoginCommand = new RelayCommand(OnLogin );

    }

    private void OnLogin(object a)
    {

        using (var context = new ProductionDatabaseContext())
        {
            var user = context.Users.FirstOrDefault(u => u.Login == Username && u.Password == CreateMD5(Password));
            if (user != null)
            {

                Window loginWindow = Application.Current.Windows.OfType<Login>().FirstOrDefault();

                // open new window MainWindow.xaml
                var mainWindow = new MainWindow();

                mainWindow.Show();
                // close Login.xaml
                loginWindow.Close();
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }


    }


    //private ICommand forgetPasswordCommand;
    //public ICommand ForgetPasswordCommand
    //{
    //    get
    //    {
    //        if (forgetPasswordCommand == null)
    //        {
    //            forgetPasswordCommand = new RelayCommand(OpenForgetPasswordView);
    //        }
    //        return forgetPasswordCommand;
    //    }
    //}

    //private void OpenForgetPasswordView()
    //{
    //    // Створіть екземпляр ViewModel для "OdzyskanieHasla.xaml"
    //    OdzyskanieHaslaViewModel odzyskanieHaslaViewModel = new OdzyskanieHaslaViewModel();

    //    // Встановіть CurrentView на ViewModel "OdzyskanieHasla.xaml"
    //    CurrentView = odzyskanieHaslaViewModel;
    //}


}
