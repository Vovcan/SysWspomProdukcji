using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWPProjekt.Helpers;
using SWPProjekt.Model;
using SWPProjekt.View;
using System.Windows;

namespace SWPProjekt.ViewModel
{
    public class TworzenieNowegoHaslaViewModel : BaseViewModel
    {
        ProductionDatabaseContext context = new ProductionDatabaseContext();
        private string _firstPassword;
        private string _secondPassword;
        public string email;
        public string FirstPassword
        {
            get { return _firstPassword; }
            set
            {
                _firstPassword = value;
            }
        }
        public string SecondPassword
        {
            get { return _secondPassword; }
            set
            {
                _secondPassword = value;
            }
        }
        public RelayCommand CreatingNewPassword { get; set; }
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
        private void SaveNewPassword(object a)
        {
            if(FirstPassword == SecondPassword)
            {

                User user = context.Users.SingleOrDefault(x => x.Email == email);
                user.Password = CreateMD5(FirstPassword);
                user.TemporaryPassword = 0;
                context.SaveChanges();
                (Application.Current.MainWindow.DataContext as LoginViewModel).CurrentView = new LoginStartPage();
            }
        }

        public TworzenieNowegoHaslaViewModel(string Email)
        {
            email = Email;
            CreatingNewPassword = new RelayCommand(SaveNewPassword);
        }
    }
}
