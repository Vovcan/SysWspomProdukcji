using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SWPProjekt.Helpers;
using System.Windows.Controls;
using System.Windows;
using SWPProjekt.View;

namespace SWPProjekt.ViewModel
{
    public class OdzyskanieHaslaViewModel : BaseViewModel
    {
        private string _secretCode;
        private string _email;
        StringBuilder code = new StringBuilder();

        public LoginViewModel LoginModel { get; set; }
        public RelayCommand SendEmailMassage { get; set; }
        public RelayCommand CheckCode { get; set; }

        public string SecretCode
        {
            get
            {
                return _secretCode;
            }
            set
            {
                _secretCode = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public void SendCode()
        {
            code.Clear();
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Дозволені символи
            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(chars.Length);
                code.Append(chars[index]);
            }

            string generatedCode = code.ToString();
            string to = Email;
            string from = "integral13376@gmail.com";
            string subject = "Password recovery code";
            string body = @"The code to be used to create a new password : " + generatedCode;
            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(from, "jaslnflrnrmjtscu"),
                EnableSsl = true,
            };
            Debug.WriteLine("Changing time out from {0} to 100.", client.Timeout);
            client.Timeout = 10000;
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Debug.WriteLine("SmtpException caught:");
                Debug.WriteLine($"Message: {ex.Message}");
                Debug.WriteLine($"Status Code: {ex.StatusCode}");
                Debug.WriteLine($"Inner Exception: {ex.InnerException}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                      ex.ToString());
            }
        }
        private void Open(object a)
        {
            SendCode();
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
        private void CodeCheker(object a)
        {
            if (SecretCode == code.ToString())
            {
                (Application.Current.MainWindow.DataContext as LoginViewModel).CurrentView = new TworzenieNowegoHasla(Email);
            }
        }
        public OdzyskanieHaslaViewModel()
        {

            SendEmailMassage = new RelayCommand(Open);
            CheckCode = new RelayCommand(CodeCheker);
        }
    }
}
