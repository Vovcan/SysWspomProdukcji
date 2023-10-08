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

public class LoginViewModel : BaseViewModel
{
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
        set { _password = value; }
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
            var user = context.Users.FirstOrDefault(u => u.Login == Username && u.Password == Password);
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


}
